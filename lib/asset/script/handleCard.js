var dataEdidCard = {}
function loadData() {
  const dataNote = [
    {
      Id: 1,
      Title: 'Lưu trữ',
      Content: 'Card 1'
    },
    {
      Id: 2,
      Title: 'Lưu trữ',
      Content: 'Card 2'
    },
    {
      Id: 3,
      Title: 'Lưu trữ',
      Content: 'Card 3'
    },
    {
      Id: 4,
      Title: 'Lưu trữ',
      Content: 'Card 4'
    },
    {
      Id: 5,
      Title: 'Lưu trữ',
      Content: 'thông tin card 5 ở đây'
    },
  ];

  dataNote.forEach((note, i) => {
    const el = `<div class="col">
      <div id="card_${note.Id}" class="card shadow">
        <div class="card-body pb-2">
          <div class="card-title fw-bold h4" aria-multiline="true" role="textbox" dir="ltr">${note.Title}</div>
          <div class="card-text" aria-multiline="true" role="textbox" dir="ltr">${note.Content}</div>
          <div class="row row-cols-3 mt-0 m-auto g-3">
            <div class="col mt-2 text-center">
              <i role="button" class="btnStorageCard iconCNCard bi bi-box-arrow-down" title="Lưu trữ"></i>
            </div>
            <div class="col mt-2 text-center">
              <i role="button" class="iconCNCard bi bi-pencil-square" data-bs-toggle="modal" data-bs-target="#modalEditNote" title="Chỉnh sửa"></i>
            </div>
            <div class="col mt-2 text-center">
              <i role="button" class="btnDelCard iconCNCard bi bi-trash" title="Xóa"></i>
            </div>
          </div>
        </div>
      </div>
    </div>`
    $(el).appendTo("#bodyContent")
  });
}

loadData()

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
  console.log(dataEdidCard);
  // push to db
  // add thành công
});

$('.btnStorageCard').click((e) => {
  const infoCard = $(e.target).offsetParent()[0];
  const codeCard = infoCard.id.split('_')[1]
  // req data
  $(infoCard.parentElement).remove()
  console.log(codeCard);
})
$('.btnDelCard').click((e) => {
  const infoCard = $(e.target).offsetParent()[0];
  const codeCard = infoCard.id.split('_')[1]
  // req data
  $(infoCard.parentElement).remove()
  console.log(codeCard);
})
