
function ShowImagePreview(imageUploader, previewImage) {
    console.log('iu', imageUploader)
    console.log('pi', previewImage)
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function jQueryAjaxPost(form) {
    console.log('form',form)
    $.validator.unobtrusive.parse(form);
    console.log('form valid', $(form).valid())
    if ($(form).valid()) {
        console.log('creating ajax config')
        var ajaxConfig = {
            type: "POST",
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $("#details").html(response)
            }
        }

        console.log('ajaxconfig', ajaxConfig)
        console.log($(form).attr('enctype'))
                                        
        if ($(form).attr('enctype') == 'multipart/form-data') {
            console.log('chegou mutipart')
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        console.log('ajaxConfig', ajaxConfig)
        $.ajax(ajaxConfig);
    }

    console.log('return false')
    return false;
}