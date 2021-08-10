var dataEdidCard = {}

document.getElementById('modalEditNote').addEventListener('show.bs.modal', (event) => {
    const elBtn = event.relatedTarget
    const infoCard = elBtn.offsetParent;
    const codeCard = infoCard.id.split('_')[1]

    const cardTitle = $(infoCard).find('.card-title').html()
    const contentCard = $(infoCard).find('.card-text').html()

    dataEdidCard.Id = codeCard;

    // console.log(cardTitle);
    // console.log(contentCard);

    $('.modal-header .titleCard').html(cardTitle);
    $('.modal-body .contentCard').html(contentCard);
});

document.getElementById('modalEditNote').addEventListener('hide.bs.modal', (event) => {
    const infoCard = `#card_${dataEdidCard.Id}`
    $(infoCard).find('.card-title').html(dataEdidCard.Title)
    $(infoCard).find('.card-text').html(dataEdidCard.Content)
});

$('#btnEditNote').click((e) => {
    dataEdidCard.Title = $('.modal-header .titleCard').html()
    dataEdidCard.Content = $('.modal-body .contentCard').html()
    //console.log(dataEdidCard);
    // push to db
    $.ajax({
        url: '/view/NoteService.asmx/editCard',
        type: 'POST',
        data: `{note: ${JSON.stringify(dataEdidCard)}}`,
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            Toast.fire({
                icon: 'success', 
                title: 'Thay đổi thành công!' 
            });
            modalEditNote.toggle();
            console.log(data);
        },
        error: (request, error) => {
            //This callback function will trigger on unsuccessful action                
            Toast.fire({
                icon: 'error', 
                title: 'Đã xảy ra lỗi! Vui lòng thử lại.' 
            });
        }
    });
    // add thành công
});

$(document).on('click', '.btnStorageCard', (e) => {
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
        url: '/view/NoteService.asmx/removeCard',
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
