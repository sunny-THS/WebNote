function editCard(el) {
  console.log(el.offsetParent.id);
}
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
  console.log(dataEdidCard);
  // push to db
  // add thành công
});
