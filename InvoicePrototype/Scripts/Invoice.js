var selectedItems="";
var itemIds="";

$(document).ready(function(){
    $(".mdc-list-item").click(function(){
        if($(this).hasClass("mdc-list-item--selected")){
            $(this).removeClass("mdc-list-item--selected")
        }
        else{
            $(this).addClass("mdc-list-item--selected");
            selectedItems=$(".mdc-list-item--selected");
            for(var index=0;index<selectedItems.length;index++){
                itemIds = itemIds + $(selectedItems[index]).attr("id") + ";";
            }
            $.ajax({
                url: 'Home/InvoiceTable?itemIds=' + itemIds,
                success: function (response) {
                $("#selectedItems").html(response);
                    $(".quantity").change(function(){
                        changeQuantity($(this).attr("id"), $(this).val())
                    });
                    }
                });
        }
    });

});

function changeQuantity(id,value){
    if(itemIds.indexOf(id+"-")!=-1){

    }
    else{
    itemIds=itemIds.replace(id+";",id+"-"+value+";");
    }
    refreshInvoiceTable();
}

function refreshInvoiceTable(){
    $.ajax({
                url: 'Home/InvoiceTable?itemIds=' + itemIds,
                success: function (response) {
                $("#selectedItems").html(response);
                    $(".quantity").change(function(){
                        changeQuantity($(this).attr("id"), $(this).val())
                    });
     }
    });
}