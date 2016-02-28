var textAsImage = (function () {

    var errorMessage = (function () {

        function show(message) {

            // If server returns the error message show it as 'Detailed description'.
            var msg = "The server encountered an error." + ((message.length > 0) ? " Detailed description: " + message : "");

            $("#error-message").text(msg).show();

            // Hide the message after 5 second.
            setTimeout(function () { $("#error-message").hide(); }, 5000);
        }
    
        return {
            show: show
        }
    })();
    
    // Represents a background image and array of text images.
    var model = (function () {

        var id = 0;
        var width = 0;
        var height = 0;
        var canvas;
        var modelItems = [];
        var selectedItem = null;
        var selectedElement = null;
        var elementStart;
        var mouseStart;
        var svgPoint;
        var delImageWidth;
        var strokeWidth;

        // Represents a text image.
        var ModelItem = function () {

            this.id = 0;
            this.modelId = 0;
            this.itemType = 0;
            this.positionLeft = 0;
            this.positionTop = 0;
            this.text = "Enter text";
            this.templateId = 1;
            this.fontSize = 21;
            this.fontColor = "#FF00FF";
            this.rotation = 0;
        };

        ModelItem.prototype.getUrl = function () {

            return "?Text=" + encodeURIComponent(this.text) + "&FontSize=" + this.fontSize + "&TemplateId=" + this.templateId + "&ItemType=" + this.itemType + "&FontColor=" + encodeURIComponent(this.fontColor) + "&Rotation=" + encodeURIComponent(this.rotation);
        }

        ModelItem.prototype.getData = function () {

            return "ModelId=" + this.modelId + "&Id=" + this.id + "&ItemType=" + this.itemType + "&PositionLeft=" + this.positionLeft + "&PositionTop=" + this.positionTop + "&Text=" + encodeURIComponent(this.text) + "&FontSize=" + this.fontSize + "&TemplateId=" + this.templateId + "&FontColor=" + encodeURIComponent(this.fontColor) + "&Rotation=" + encodeURIComponent(this.rotation);
        }

        // Show bounding rectangle and Delete image.
        ModelItem.prototype.select = function () {

            $("#rect" + this.id).show();
            $("#del" + this.id).show();
        }

        // Hide bounding rectangle and Delete image.
        ModelItem.prototype.deselect = function () {

            $("#rect" + this.id).hide();
            $("#del" + this.id).hide();
        }

        // Update information about text image on the server.
        ModelItem.prototype.updateDatabase = function () {

            $.ajax({
                url: basePath + "api/ModelItem/Update/",
                type: 'POST',
                dataType: 'json',
                data: this.getData(),

                error: function (xhr, textStatus, errorThrown) {
                    errorMessage.show(errorThrown);
                }
            });
        }

        // Called if attribute or position of text image was changed.
        ModelItem.prototype.change = function () {

            this.updateDatabase();

            $("#img" + this.id)[0].setAttributeNS('http://www.w3.org/1999/xlink', 'href', basePath + "api/Image/ModelItem/" + this.id + "/" + this.getUrl());

            $("#hidden-img" + this.id).attr('src', basePath + "api/Image/ModelItem/" + this.id + "/" + this.getUrl());
        }

        // Represents a text template gallery.
        var textSelector = (function () {

            var selectedItemId = 0;
            var selectedGalleryId = 0;
            var textGallery = [];
            var scrollTop = 0
            var dialog;

            function init() {

                loadData();

                selectedItemId = $("#btn-template").data("text-template-id");              
                selectedGalleryId = $("#btn-template").data("text-template-gallery-id");  

                dialog = $("#text-templates-dialog").dialog({
                    title: "Select template",
                    autoOpen: false,
                    dialogClass: "xui-dialog",
                    modal: true,
                    buttons: {
                        Cancel: function() {
                            dialog.dialog( "close" );
                        }
                    }
                });

                $("#btn-template").on("click", function () {

                    $("#text-gallery-list").val(selectedGalleryId);

                    showGallery();

                    dialog.dialog("open");

                    $("#text-templates-holder").scrollTop(scrollTop);

                });

                $("#text-gallery-list").on("change", function () {

                    selectedGalleryId = $("#text-gallery-list").val(); 
                    showGallery();

                    $("#text-templates-holder").scrollTop(scrollTop);
                });
            }

            function loadData() {

                $.ajax({
                    type: "GET",
                    url: basePath + "api/TextGallery/List/",
                    dataType: 'json',

                    success: function (data) {

                        data.forEach(function (gallery) {

                            var tg = {
                                id: gallery.Id,
                                name: gallery.Name,
                                items: []
                            }

                            gallery.Items.forEach(function (item) {

                                tg.items.push({
                                    id: item.Id,
                                    name: item.Name,
                                    textColor1: argbToRGB(item.TextColor1)
                                });
                            })

                            textGallery[tg.id] = tg;
                        })
                    },

                    error: function (xhr, textStatus, errorThrown) {
                        errorMessage.show(errorThrown);
                    }
                });
            }

            function showGallery() {

                if ($("#text-gallery")) {
                    $("#text-gallery").remove();
                }

                var $textTemplateGallery = $("<div>", { id: "text-gallery" });

                var i = 0;
                var indx = 0;

                textGallery[selectedGalleryId].items.forEach(function (item) {

                    var $div = $("<div>", { id: "text-template" + item.id });

                    $div.attr({
                        "data-id": item.id,
                        "data-name": item.name,
                        "data-text-color1": item.textColor1
                    });

                    if (item.id == selectedItemId) {

                        $div.addClass("text-template-item-selected");

                        indx = i;
                    }

                    $div.append($("<img>", { 
                        id: "text-template-img" + item.id, 
                        src: basePath + "api/TextTemplate/Image/" + item.id + "/"
                    }));


                    $div.on("click", function (e) {

                        e.stopPropagation();

                        selectedItemId = $(this).data("id")
                        $("#template-name").text($(this).data("name"));
                        $("#font-color").spectrum("set", $div.attr("data-text-color1"));

                        if (selectedItem != null) {
                            selectedItem.templateId = $(this).data("id");
                            selectedItem.fontColor = $div.attr("data-text-color1");
                            selectedItem.change();
                        }

                        dialog.dialog("close");
                    })

                    $textTemplateGallery.append($div);

                    i++;
                });

                $("#text-templates-holder").append($textTemplateGallery);

                scrollTop = 0;
                if (indx > 2) {
                    scrollTop = indx * 106;
                }
            }

            function setTextTemplate(itemId) {

                textGallery.forEach(function (gallery) {

                    gallery.items.forEach(function (item) {

                        if (item.id == itemId) {

                            selectedItemId = itemId;
                            selectedGalleryId = gallery.id;
                            $("#template-name").text(item.name);
                        }
                    })
                })
            }

            function getSelectedItemId() {
                return selectedItemId;
            }

            return {
                init: init,
                setTextTemplate: setTextTemplate,
                getSelectedItemId: getSelectedItemId
            }

        })();

        // Represents a clipart gallery.
        var clipartSelector = (function () {

            var selectedGallery = 1;
            var cliaprtGallery = [];
            var dialog;

            function init() {

                loadData();

                selectedGallery = $("#clipart-gallery-list  option:first").val();

                dialog = $("#clipart-template-dialog").dialog({
                    title: "Select clipart",
                    autoOpen: false,
                    dialogClass: "xui-dialog",
                    modal: true,
                    buttons: {
                        Cancel: function () {
                            dialog.dialog("close");
                        }
                    }
                });

                $("#btn-template-clipart").on("click", function () {

                    $("#clipart-gallery-list").val(selectedGallery);

                    showGallery();

                    dialog.dialog("open");
                });

                $("#clipart-gallery-list").on("change", function () {

                    selectedGallery = $("#clipart-gallery-list").val();

                    showGallery();

                    $("#clipart-templates-holder").scrollTop(0);
                });
            }

            function loadData() {

                $.ajax({
                    type: "GET",
                    url: basePath + "api/ClipartGallery/List/",
                    dataType: 'json',

                    success: function (data) {

                        data.forEach(function (gallery) {

                            var cg = {
                                id: gallery.Id,
                                name: gallery.Name,
                                items: []
                            };

                            gallery.Items.forEach(function (item) {

                                cg.items.push({
                                    id: item.Id,
                                    name: item.Name,
                                    text: item.Text,
                                    textColor1: argbToRGB(item.TextColor1)
                                });
                            })

                            cliaprtGallery[cg.id] = cg;
                        })
                    },

                    error: function (xhr, textStatus, errorThrown) {
                        errorMessage.show(errorThrown);
                    }
                });
            }

            function showGallery() {

                if ($("#clipart-gallery")) {
                    $("#clipart-gallery").remove();
                }

                var $clipartGallery = $("<div>", {
                    id: "clipart-gallery"
                });

                cliaprtGallery[selectedGallery].items.forEach(function (item) {

                    var $div = $("<div>", {
                        id: "clipart-template" + item.id,
                        on: {                     
                            click: onClickClipart
                        }
                    });

                    $div.attr({
                        "data-id": item.id,
                        "data-text": item.text,
                        "data-text-color1": item.textColor1
                    });

                    $div.append($("<img>", { 
                        id: "clipart-template-img" + item.id, 
                        src: basePath + "api/ClipartTemplate/Image/" + item.id + "/"
                    }));

                    $clipartGallery.append($div);
                });

                $("#clipart-templates-holder").append($clipartGallery);
            }

            function onClickClipart(e) {

                e.stopPropagation();

                $div = $(e.target).parent();

                $("#font-color").spectrum("set", $div.attr("data-text-color1"));

                var modelItem = new ModelItem();
                modelItem.id = 0;
                modelItem.modelId = id;
                modelItem.itemType = 1;
                modelItem.text = $div.attr("data-text");
                modelItem.templateId = $div.attr("data-id");
                modelItem.fontSize = $("#font-size").val();
                modelItem.fontColor = $div.attr("data-text-color1");
                modelItem.rotation = $("#rotation").val();

                $.ajax({
                    url: basePath + "api/Model/AddModelItem/",
                    type: 'PUT',
                    dataType: 'json',
                    data: modelItem.getData(),
                    success: function (modelItemId) {

                        modelItem.id = modelItemId;
                        addModelItem(modelItem);
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        errorMessage.show(errorThrown);
                    }
                });

                dialog.dialog("close");
            }

            return {
                init: init
            }
        })();


        function init() {

            textSelector.init();
            clipartSelector.init();

            // Get a reference to the SVG element 
            canvas = document.getElementById("canvas");

            // Creates a SVGPoint object
            svgPoint = canvas.createSVGPoint();

            $(canvas).on("click", function () {

                // Hide bounding rectangle and Delete image.
                deselectItem();

                $("#sample-text").val("");
                $("#btn-add-text").prop('disabled', false).removeClass('disable');
                $("#sample-text").prop('disabled', false);
            });

            $("#font-size").on("change", function () {

                if (selectedItem != null) {
                    selectedItem.fontSize = $("#font-size").val();
                    selectedItem.change();
                }
            });

            $("#rotation").on("change", function () {

                if (selectedItem != null) {
                    selectedItem.rotation = $("#rotation").val();
                    selectedItem.change();
                }
            });

            // Initialize color picker
            $("#font-color").spectrum({
                color: "#FF0000",
                chooseText: "Ok",

                change: function (color) {

                    if (selectedItem != null) {

                        selectedItem.fontColor = color.toHexString();
                        selectedItem.change();
                    }
                }
            });

            $("#font-color").spectrum("set", $("#btn-template").data("text-template-text-color1"));

            $("#sample-text").on("input", function () {

                if ($("#sample-text").val().length > 0) {

                    if (selectedItem != null) {
                        selectedItem.text = $("#sample-text").val();
                        selectedItem.change();
                    }
                }
            });

            $("#btn-add-text").on("click", function () {

                if ($("#sample-text").val().length > 0) {

                    // Create new text image.
                    var modelItem = new ModelItem();
                    modelItem.id = 0;
                    modelItem.modelId = id;
                    modelItem.itemType = 0;
                    modelItem.text = $("#sample-text").val();
                    modelItem.templateId = textSelector.getSelectedItemId();
                    modelItem.fontSize = $("#font-size").val();
                    modelItem.fontColor = $("#font-color").spectrum("get").toHexString();
                    modelItem.rotation = $("#rotation").val();

                    $.ajax({
                        url: basePath + "api/Model/AddModelItem/",
                        type: 'PUT',
                        dataType: 'json',
                        data: modelItem.getData(),

                        success: function (modelItemId) {

                            modelItem.id = modelItemId;

                            addModelItem(modelItem);
                        },

                        error: function (xhr, textStatus, errorThrown) {
                            errorMessage.show(errorThrown);
                        }
                    });
                }
            });
        }

        // Add background image.
        function addModel(modelId, modelWidth, modelHeight) {

            id = modelId;
            width = modelWidth;
            height = modelHeight;

            var svgBackgroundImg = document.createElementNS('http://www.w3.org/2000/svg', 'image');
            svgBackgroundImg.setAttribute('id', "model" + id);
            svgBackgroundImg.setAttribute('height', "100%");
            svgBackgroundImg.setAttribute('width', "100%");
            svgBackgroundImg.setAttributeNS('http://www.w3.org/1999/xlink', 'href', basePath + "api/Model/Image/" + id + "/");
            svgBackgroundImg.setAttribute('x', '0');
            svgBackgroundImg.setAttribute('y', '0');
            canvas.setAttribute("style", "margin-left: auto; margin-right: auto; max-width: " + modelWidth + "px;");
            canvas.setAttribute("viewBox", "0 0 " + modelWidth + " " + modelHeight);

            canvas.appendChild(svgBackgroundImg);

            if (detectIE()) {

                var imgHeigth = modelHeight;

                if (modelWidth - $("#image-main").width() > 0){

                    imgHeigth = modelHeight * $("#image-main").width() / modelWidth;
                }

                $("#image-main").css("height", imgHeigth + "px");
            }

            // Set URL for downloading the resulting image.
            $("#form-save-result").attr("action", basePath + "api/Image/Result/" + id);

            // Set size for Delete image and thickness for bounding rectangle depending on the width of the background image.
            setDelImageSize();
        }

        function addModelFromSample(data) {

            // Add background image.
            addModel(data.Id, data.ImageWidth, data.ImageHeight);

            for (var i = 0; i < data.Items.length; i++) {
                var modelItem = data.Items[i];

                var mi = new ModelItem();
                mi.id = modelItem.Id;
                mi.modelId = data.Id;
                mi.itemType = modelItem.ItemType;
                mi.text = modelItem.Text;
                mi.fontSize = modelItem.FontSize;
                mi.templateId = modelItem.TemplateId;
                mi.fontColor = modelItem.FontColor;
                mi.rotation = modelItem.Rotation;
                mi.positionLeft = modelItem.PositionLeft;
                mi.positionTop = modelItem.PositionTop;

                addModelItem(mi);

                if (i == data.Items.length - 1) {
                    selectItem(mi.id);
                }
            }
        }

        // Add text image.
        function addModelItem(modelItem) {

            var svgGroup = document.createElementNS("http://www.w3.org/2000/svg", 'g');
            svgGroup.setAttribute("id", "img-group" + modelItem.id);

            // Add bounding rectangle.
            var svgRect = document.createElementNS("http://www.w3.org/2000/svg", 'rect');
            svgRect.setAttribute('id', "rect" + modelItem.id);
            svgRect.setAttribute('x', modelItem.positionLeft);
            svgRect.setAttribute('y', modelItem.positionTop);
            svgRect.setAttribute('height', "0");
            svgRect.setAttribute('width', "0");
            svgRect.setAttribute('stroke', "red");
            svgRect.setAttribute('stroke-width', rectangleThickness);
            svgRect.setAttribute('stroke-dasharray', "5");
            svgRect.setAttribute('fill-opacity', "0.4");
            svgRect.setAttribute('fill', "none");
            svgRect.style.display = "none";

            svgGroup.appendChild(svgRect);

            // Add image generated from the text.
            var svgTextImg = document.createElementNS("http://www.w3.org/2000/svg", 'image');
            svgTextImg.setAttribute('id', "img" + modelItem.id);
            svgTextImg.setAttribute('height', "0");
            svgTextImg.setAttribute('width', "0");
            svgTextImg.setAttributeNS('http://www.w3.org/1999/xlink', 'href', basePath + "api/Image/ModelItem/" + modelItem.id + "/" + modelItem.getUrl());
            svgTextImg.setAttribute('x', modelItem.positionLeft);
            svgTextImg.setAttribute('y', modelItem.positionTop);
            svgTextImg.style.cursor = "move";

            svgGroup.appendChild(svgTextImg);

            // Add Delete image.
            var svgDelImg = document.createElementNS("http://www.w3.org/2000/svg", 'image');
            svgDelImg.setAttribute('id', "del" + modelItem.id);
            svgDelImg.setAttributeNS('http://www.w3.org/1999/xlink', 'href', basePath + "Content/Images/delete.png");
            svgDelImg.setAttribute('x', modelItem.positionLeft);
            svgDelImg.setAttribute('y', modelItem.positionTop - 16);
            svgDelImg.style.display = "none";
            svgDelImg.style.cursor = "pointer";
            svgDelImg.setAttribute('height', delImageSize);
            svgDelImg.setAttribute('width', delImageSize);

            svgGroup.appendChild(svgDelImg);

            // Add the hole group: bounding rectangle, image generated from the text and Delete image to canvas.
            canvas.appendChild(svgGroup);

            // Create hidden additional image. When it is loaded its width and height set to svgRect and svgTextImg items.
            var $hiddenImg = $("<img>", {
                id: "hidden-img" + modelItem.id,
                src: basePath + "api/Image/ModelItem/" + modelItem.id + "/" + modelItem.getUrl()
            });

            $("#hidden-images").append($hiddenImg);

            // Attach events.
            $($hiddenImg).on("load", onLoadImage);
            $(svgTextImg).on("mousedown", onMouseDown);
            $(svgTextImg).on("mouseup", onMouseUp);
            $(svgTextImg).on("click", onClick);
            $(svgTextImg).on("touchstart", onTouchstart);
            $(svgTextImg).on("touchend", onTouchEnd);
            $(svgDelImg).on("click", onClickDelete);

            modelItems.push(modelItem);

            // Select added item: bounding rectangle and Delete image are visible.
            selectItem(modelItem.id);
        }

        // Show bounding rectangle and Delete image. Set values for visual controls for selected text image.
        function selectItem(id) {

            // If selected, deselect text image.
            deselectItem();

            // Find text image by id and set it as selected.
            modelItems.forEach(function (item) {

                if (item.id == id) {
                    selectedItem = item;
                }
            });

            if (selectedItem != null) {

                // Show bounding rectangle and Delete image.
                selectedItem.select();

                selectedElement = document.getElementById("img" + id);

                // Set values for visual controls for selected text image.
                $("#sample-text").val(selectedItem.text);
                $("#font-size").val(selectedItem.fontSize);
                $("#font-color").spectrum("set", selectedItem.fontColor);

                $("#rotation").val(selectedItem.rotation);
                $("#btn-add-text").prop('disabled', true).addClass('disable');

                if (selectedItem.itemType == 1) {
                    $("#sample-text").prop('disabled', true);
                    $("#btn-template").prop('disabled', true).addClass('disable');
                }
                else {
                    $("#sample-text").prop('disabled', false);
                    $("#btn-template").prop('disabled', false).removeClass('disable');
                }

                textSelector.setTextTemplate(selectedItem.templateId);
            }
        }

        // Deselect text image: hide bounding rectangle and Delete image.
        function deselectItem() {

            if (selectedItem != null) {

                selectedItem.deselect();
                selectedItem = null;
            }
        }

        function onMouseDown(e) {

            e.stopPropagation();
            e.preventDefault();

            mouseStart = cursorPoint(e);
            elementStart = {
                x: e.target['x'].animVal.value,
                y: e.target['y'].animVal.value
            };

            $(e.target).on("mousemove", onMouseMove);

            selectItem(e.target.id.substring(3));
        }

        function onMouseMove(e) {

            e.stopPropagation();
            e.preventDefault();

            var id = e.target.id.substring(3);

            var current = cursorPoint(e);
            svgPoint.x = current.x - mouseStart.x;
            svgPoint.y = current.y - mouseStart.y;

            var m = e.target.getTransformToElement(canvas).inverse();

            m.e = m.f = 0;
            svgPoint = svgPoint.matrixTransform(m);

            // Set new position for text image, bounding rectangle and Delete image.
            $("#img" + id).attr({
                "x": elementStart.x + svgPoint.x,
                'y': elementStart.y + svgPoint.y
            });
            $("#rect" + id).attr({
                "x": elementStart.x + svgPoint.x,
                'y': elementStart.y + svgPoint.y
            });
            $("#del" + id).attr({
                "x": elementStart.x + svgPoint.x + parseInt($("#img" + id).attr("width")),
                'y': elementStart.y + svgPoint.y - delImageSize
            });

            if (selectedItem != null) {

                selectedItem.positionLeft = Math.round(elementStart.x + svgPoint.x);
                selectedItem.positionTop = Math.round(elementStart.y + svgPoint.y);
            }
        }

        function onMouseUp(e) {

            e.stopPropagation();
            e.preventDefault();

            $(e.target).off("mousemove", onMouseMove);

            if (selectedElement != null) {
                selectedElement = null;
            }
            
            if (selectedItem != null) {
                selectedItem.updateDatabase();
            }
        }


        function onTouchstart(e) {

            e.stopPropagation();
            e.preventDefault();

            mouseStart = cursorPoint(e.originalEvent.touches[0]);
            elementStart = {
                x: e.target['x'].animVal.value,
                y: e.target['y'].animVal.value
            };

            $(e.target).on("touchmove", onTouchMove);

            selectItem(e.target.id.substring(3));
        }

        function onTouchMove(e) {

            e.stopPropagation();
            e.preventDefault();

            var id = e.target.id.substring(3);

            var current = cursorPoint(e.originalEvent.touches[0]);
            svgPoint.x = current.x - mouseStart.x;
            svgPoint.y = current.y - mouseStart.y;

            var m = e.target.getTransformToElement(canvas).inverse();

            m.e = m.f = 0;
            svgPoint = svgPoint.matrixTransform(m);

            // Set new position for text image, bounding rectangle and Delete image.
            $("#img" + id).attr({
                "x": elementStart.x + svgPoint.x,
                'y': elementStart.y + svgPoint.y
            });
            $("#rect" + id).attr({
                "x": elementStart.x + svgPoint.x,
                'y': elementStart.y + svgPoint.y
            });
            $("#del" + id).attr({
                "x": elementStart.x + svgPoint.x + parseInt($("#img" + id).attr("width")),
                'y': elementStart.y + svgPoint.y - delImageSize
            });

            if (selectedItem != null) {

                selectedItem.positionLeft = Math.round(elementStart.x + svgPoint.x);
                selectedItem.positionTop = Math.round(elementStart.y + svgPoint.y);
            }
        }

        function onTouchEnd(e) {

            e.stopPropagation();
            e.preventDefault();

            $(e.target).off("touchmove", onTouchMove);

            if (selectedElement != null) {
                selectedElement = null;
            }

            if (selectedItem != null) {
                selectedItem.updateDatabase();
            }
        }


        function onClick(e) {

            e.stopPropagation();
            e.preventDefault();
        }

        function onClickDelete(e) {

            e.stopPropagation();

            if (selectedItem != null) {

                // Send request to delete text image on the server.
                $.ajax({
                    url: basePath + "api/ModelItem/Delete/",
                    type: 'DELETE',
                    dataType: 'json',
                    data: selectedItem.getData(),

                    success: function () {

                        $("#img-group" + selectedItem.id).remove();

                        modelItems.splice($.inArray(selectedItem, modelItems), 1);
                    },

                    error: function (xhr, textStatus, errorThrown) {
                        errorMessage.show(errorThrown);
                    }
                });
            }
        }

        // When hidden image is loaded set width and height for text image and bounding rectangle. And set position for Delete image.
        function onLoadImage(e) {

            var id = this.id.substring(10);

            $("#img" + id).attr("width", this.width);
            $("#img" + id).attr("height", this.height);
            $("#rect" + id).attr("width", this.width);
            $("#rect" + id).attr("height", this.height);
            $("#del" + id).attr("x", parseInt($("#img" + id).attr("x")) + this.width);
            $("#del" + id).attr("y", parseInt($("#img" + id).attr("y")) - delImageSize);
        }

        function setDelImageSize() {

            if (width < 800) {
                delImageSize = 24;
                rectangleThickness = 1;
            }
            else if (width < 1600) {
                delImageSize = 32;
                rectangleThickness = 2;
            }
            else if (width < 2400) {
                delImageSize = 48;
                rectangleThickness = 3;
            }
            else if (width < 3200) {
                delImageSize = 64;
                rectangleThickness = 4;
            }
            else {
                delImageSize = 128;
                rectangleThickness = 6;
            }
        }

        function cursorPoint(evt) {
            svgPoint.x = evt.clientX;
            svgPoint.y = evt.clientY;
            return svgPoint.matrixTransform(canvas.getScreenCTM().inverse());
        }

        // Convert Color from ARGB format to RGB format.
        function argbToRGB(color) {

            return '#' + ('000000' + (color & 0xFFFFFF).toString(16)).slice(-6);
        }

        // Return version of IE or false if browser isn`t IE.
        function detectIE() {
            var ua = window.navigator.userAgent;

            var msie = ua.indexOf('MSIE ');
            if (msie > 0) {
                // IE 10 or older => return version number.
                return parseInt(ua.substring(msie + 5, ua.indexOf('.', msie)), 10);
            }

            var trident = ua.indexOf('Trident/');
            if (trident > 0) {
                // IE 11 => return version number.
                var rv = ua.indexOf('rv:');
                return parseInt(ua.substring(rv + 3, ua.indexOf('.', rv)), 10);
            }

            var edge = ua.indexOf('Edge/');
            if (edge > 0) {
                // Edge (IE 12+) => return version number.
                return parseInt(ua.substring(edge + 5, ua.indexOf('.', edge)), 10);
            }

            // Other browser.
            return false;
        }

        return {
            init: init,
            addModel: addModel,
            addModelFromSample: addModelFromSample,
            addModelItem: addModelItem
        }
    })();

    var sampleSelector = (function () {

        var model = null;
        var samplePageIndex = 0;
        var sampleTotalPage = 0;

        function init(modelParam) {

            model = modelParam;

            sampleTotalPage = $('#samples-holder').data("sample-total-page");

            // Show previous items from the Sample gallery
            $("#btn-sample-prev").on("click", function (e) {

                if (samplePageIndex > 0) {

                    changeSamplePage(-1);
                }
            });

            // Show next items from the Sample gallery
            $("#btn-sample-next").on("click", function (e) {

                if (samplePageIndex < sampleTotalPage) {

                    changeSamplePage(1);
                }
            });

            $(".sample > div").on("click", function (event) {

                var id = $(this).children().first().data("id");

                if (id > 0) {
                    $.ajax({
                        url: basePath + "api/Model/CreateFromSample/" + id + "/", //ToDo - Check?????
                        type: "PUT",
                        dataType: "json",
                        data: "templateId=" + id,

                        success: function (data) {
                            $("#select-image").remove();
                            $("#image-worker").show();

                            model.addModelFromSample(data);
                        },

                        error: function (xhr, textStatus, errorThrown) {
                            errorMessage.show(errorThrown);
                        }
                    });
                }
            });
        }

        function changeSamplePage(pageIncrement) {

            samplePageIndex += pageIncrement;

            if (samplePageIndex == 0){
                $("#btn-sample-prev").prop('disabled', true).addClass('disable');
            }
            else {
                $("#btn-sample-prev").prop('disabled', false).removeClass('disable');
            }

            if (samplePageIndex == sampleTotalPage) {
                $("#btn-sample-next").prop('disabled', true).addClass('disable');
            }
            else {
                $("#btn-sample-next").prop('disabled', false).removeClass('disable');
            }

            $.ajax({
                type: "GET",
                url: basePath + "api/Sample/List/",
                dataType: 'json',
                data: "samplePageIndex=" + samplePageIndex, 

                success: function (sampleIds) {

                    var count = 0;

                    sampleIds.forEach(function (item, i) {
                        $("#sample" + i).attr("src", basePath + "api/Sample/Thumbnail/" + item + "/").attr("data-id", item).parent().addClass('sample-item');
                        count++;
                    })

                    for(var i = count; i < 8; i++){
                        $("#sample" + i).attr("src", basePath + "Content/Images/empty-sample.png").attr("data-id", 0).parent().removeClass('sample-item');
                    }
                },

                error: function (xhr, textStatus, errorThrown) {
                    errorMessage.show(errorThrown);
                }
            });
        }

        return {
            init: init
        }
    })();

    var fileUpload = (function () {

        var model = null;

        function uploadFile(files) {

            var data = new FormData();

            // Add the uploaded image content to the form data collection.
            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
            }

            // Upload background image to the server.
            $.ajax({
                type: "POST",
                url: basePath + "api/Model/UploadFile/",
                contentType: false,
                processData: false,
                data: data,
                //timeout:5000,

                success: function (data) {

                    $("#select-image").remove();
                    $("#image-worker").show();

                    model.addModel(data.Id, data.ImageWidth, data.ImageHeight);
                },

                error: function (xhr, textStatus, errorThrown) {
                    errorMessage.show(errorThrown);
                }
            });
        }


        function init(modelParam) {

            model = modelParam;

            $('#drop-file').on('dragover', function (e) {

                e.preventDefault();
                e.stopPropagation();
            });

            $('#drop-file').on('dragenter', function (e) {

                e.preventDefault();
                e.stopPropagation();
            });

            $('#drop-file').on('drop', function (e) {

                if (e.originalEvent.dataTransfer) {

                    if (e.originalEvent.dataTransfer.files.length) {

                        e.preventDefault();
                        e.stopPropagation();

                        uploadFile(e.originalEvent.dataTransfer.files);
                    }
                }
            });

            // If user selects the background image upload it to the server.
            $('#fileUpload').on('change', function () {

                uploadFile($("#fileUpload").get(0).files);
            });
        }

        return {
            init: init,
        }
    })();
 
    function init() {

        model.init();
        sampleSelector.init(model);
        fileUpload.init(model);

        // Fix bag for Chrome v48.
        SVGElement.prototype.getTransformToElement = SVGElement.prototype.getTransformToElement || function (elem) {
            return elem.getScreenCTM().inverse().multiply(this.getScreenCTM());
        };
    };

    return {
        init: init
    }
})();

$(function () {
    textAsImage.init();
});