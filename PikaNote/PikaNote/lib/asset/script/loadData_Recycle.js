function loadData() {
    var dataNote = [];
    const name = $('#logoUser').attr( "title" )
    $.ajax({
        url: '/view/NoteService.asmx/getCard_Recycle',
        type: 'POST',
        data: `{TenDN: ${JSON.stringify(name)}}`,
        contentType:"application/json; charset=utf-8",
        success: (data) => {
            dataNote = data.d;

            console.log(dataNote);
            dataNote.forEach((note, i) => {
                const el = `<div class="col">
                    <div id="card_${note.Id}" class="card shadow">
                        <div class="card-body pb-2">
                            <div class="card-title fw-bold h4" aria-multiline="true" role="textbox" dir="ltr">${note.Title}</div>
                            <div class="card-text" aria-multiline="true" role="textbox" dir="ltr">${note.Content}</div>
                            <div class="row row-cols-2 mt-0 m-auto g-3">
                                <div class="col mt-2 text-center">
                                    <i role="button" class="btnDelCard iconCNCard bi bi-trash" title="Xóa"></i>
                                </div>
                                <div class="col mt-2 text-center">
                                    <i role="button" class="btnRestore iconCNCard bi bi-arrow-repeat" title="Khôi phục"></i>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`
                $(el).appendTo("#bodyContent");
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
}
loadData();