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

function showTaskMenu() {
    $(document).ready(function () {
        $('#tasksElementId').mousemove(function (e) {
            event.preventDefault();
            if (event.button == 2) {
                $('#contextMenuId').is(':visible')
                {
                    $('#contextMenuId').show();
                    $("#contextMenuId").css('left', (e.pageX + 10) + 'px').css('top', (e.pageY + 10) + 'px');
                }
            }
        });
    });

}

function showDetails() {
    if ($('#detail').width() == 0) {
        $('#detail').width(367);
    }
    else {
        $('#detail').width(0);
    }
}

function allowChange() {
    $('#taskTextField').removeClass('hidden');
    $('#taskNameId').addClass('hidden');
}
function stopChangeTaskName() {
    $('#taskTextField').addClass('hidden');
    $('#taskNameId').removeClass('hidden');
}
function showTextAriaNote() {
    $('#textFieldNote').removeClass('hidden');
    $('#textFieldNoteId').removeClass('hidden');
    $('#taskNoteId').addClass('hidden');
}

function stopAddingNode() {
    $('#textFieldNote').addClass('hidden');
    $('#textFieldNoteId').addClass('hidden');
    $('#taskNoteId').removeClass('hidden');

}

function showSubtuckEdit() {
    $('#subtaskInputId').removeClass('hidden');
    $('#subtaskViewId').addClass('hidden');

}

function showEditSubtask() {
    $('#existingSubtaskEdit').removeClass('hidden');
    $('#existingSubtask').addClass('hidden');
}

function hideEditSubtask() {
    $('#existingSubtask').removeClass('hidden');
    $('#existingSubtaskEdit').addClass('hidden');
}
function hideContextMenu() {
    $('#contextMenuId').hide();
}

function loadDetails() {
    var el = document.querySelector('#detail');
    el.classList += 'transition';
}

function datePickerShow() {
    $.datepicker.setDefaults($.extend($.datepicker.regional["ru"]));

    $('#datepicker').datepicker({
        showButtonPanel: true,
        dateFormat: "yy-mm-dd",
        beforeShow: function (input) {
        },
        onSelect: function (dateText, inst) {
            $(this).css("text-decoration-color", "#67ae2b");

        },
        onClose: function (dateText, inst) {
            $(this).focus();
        }
    });
}