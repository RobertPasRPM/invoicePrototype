$(document).ready(function(){
    console.log("Start");
    $(".mdc-list-item").click(function(){
        if($(this).hasClass("mdc-list-item--selected")){
            $(this).removeClass("mdc-list-item--selected")
        }
        else{
            $(this).addClass("mdc-list-item--selected");
            var itemId = $(this).attr("id");
            console.log(itemId);

            $("#selectedItems").load('Home/InvoiceTable?itemId=' + itemId);
        }
    });
});