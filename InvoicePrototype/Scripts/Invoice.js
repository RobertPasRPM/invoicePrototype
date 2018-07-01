$(document).ready(function(){
    $(".mdc-list-item").click(function(){
        if($(this).hasClass("mdc-list-item--selected")){
            $(this).removeClass("mdc-list-item--selected")
        }
        else{
            $(this).addClass("mdc-list-item--selected");
            var listOfItems=$(".mdc-list-item--selected");
            var itemIds="";
            for(var index=0;index<listOfItems.length;index++){
                itemIds=itemIds+$(listOfItems[index]).attr("id") + ";";
            }
            $.ajax({
                url: 'Home/InvoiceTable?itemIds=' + itemIds,
                success: function (response) {               
                    $("#selectedItems").html(response);
                    }
                });
        }
    });
});