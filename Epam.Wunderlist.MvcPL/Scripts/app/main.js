function stopSearch(){
	$("#stopSearchIconId").hide();
	$("#searchInput").val("");
	$("#searchIconId").show();
}
function startSearch()
{
	$("#searchIconId").hide();
	$("#stopSearchIconId").show();
}
function collapseNavBar()
{
	if($('#lists').hasClass('navigationMenucollapsed')) {
  		$('#lists').removeClass("navigationMenucollapsed").addClass("navigationMenu");
 	} 
 	else {
  		$('#lists').removeClass("navigationMenu").addClass("navigationMenucollapsed");
 	}
}
function chooseTaskList(id)
{
	if($('#'+id).hasClass('slidebarItem')) {
  		$('#'+id).removeClass("slidebarItem").addClass("slidebarItemActive");
  		$('#titleNameId').text($(".task-name").text());

 	} 
 	else {
  	$('#'+id).removeClass("slidebarItemActive").addClass("slidebarItem");
 	}
}
function chooseTaskOwnerList(id) {
    var lists = $("li[name='listItem']");
    for (var index = 0; index < lists.length; ++index) {
        var element = lists[index];
        if (element.hasAttribute('class', 'slidebarItem-owner-list-active')) {
            element.removeAttribute('class', 'slidebarItem-owner-list-active');
            $('#' + element.id).children('a').children('span').css('class', 'list-options').prop('hidden', true);
        }
    }
    $('#' + id).addClass('slidebarItem-owner-list-active');
    $('#' + id).children('a').children('span').css('class', 'list-options').prop('hidden', false);
}

function addTaskList(){
	$('#addListModal').show();
}

function addTaskList() {
    $('#editListModal').show();
}

function inputNameOfList(id){

		$('#' + id).button({'aria-disabled' : false});
		$('#' + id).removeClass("submit-full-blue-disabled").addClass("submit-full-blue-enable");		
	
}

function disableSave(){
 
 	if ($('#listName').val() == "")
		{
			$('#saveButtonId').button({'aria-disabled' : true});
		    $('#saveButtonId').removeClass("submit-full-blue-enable").addClass("submit-full-blue-disabled");
		}
}

function stopCreatingList(){
	$('#addListModal').hide();
}

function stopCreatingList() {
    $('#editListModal').hide();
}

function userMenuShow(){
	if($( '#user-popover').is(':visible')){
		$('#user-popover').hide();
	}else{
		$('#user-popover').show();
	}
	
}

function showHideElement (elId){	
	if ($('#' + elId).is(':visible')){
		$('#' + elId).hide();
	}else{
		$('#' + elId).show();
	}
}

//$(document).ready(function() {
//    $('#file-input').change(function(event) {
//        var selectedFile = event.target.files[0];
//        if (!selectedFile.type.match('image.*')) {
//            return;
//        }
//        var reader = new FileReader();
//        reader.onload = function (event) {
//            debugger;
//            console.log(event.target.result);
//            $("#avatar").attr('src', event.target.result);
//        };
//        reader.readAsDataURL(selectedFile);
//    });
//});

