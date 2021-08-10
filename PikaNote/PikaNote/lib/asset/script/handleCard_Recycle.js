$(document).on('click', '.btnRestore', (e) => {
    const infoCard = $(e.target).offsetParent()[0];
    const codeCard = infoCard.id.split('_')[1];
    // req data
    $.ajax({
        url: '/view/NoteService.asmx/defaultCard',
        type: 'POST',
        data: `{id: ${codeCard}}`,
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            console.log(data.d);
            $(infoCard.parentElement).remove()
        },
        error: (request, error) => {
            //This callback function will trigger on unsuccessful action                
            Toast.fire({
                icon: 'error', 
                title: 'Đã xảy ra lỗi! Vui lòng thử lại.' 
            });
        }
    });
});

$(document).on('click', '.btnDelCard', (e) => {
    const infoCard = $(e.target).offsetParent()[0];
    const codeCard = infoCard.id.split('_')[1]
    // req data
    $.ajax({
        url: '/view/NoteService.asmx/DeleteCard',
        type: 'POST',
        data: `{id: ${codeCard}}`,
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            console.log(data.d);
            $(infoCard.parentElement).remove();
            Toast.fire({
                icon: 'success', 
                title: 'Xóa thành công' 
            });
        },
        error: (request, error) => {
            //This callback function will trigger on unsuccessful action                
            Toast.fire({
                icon: 'error', 
                title: 'Đã xảy ra lỗi! Vui lòng thử lại.' 
            });
        }
    });
});
