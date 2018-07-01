var selectedItems=[];
var itemIds="";

$(document).ready(function(){
    $(".mdc-list-item").click(function(){
        if($(this).hasClass("mdc-list-item--selected")){
            $(this).removeClass("mdc-list-item--selected")
        }
        else{
            $(this).addClass("mdc-list-item--selected");
            selectedItems.push($(this));
            itemIds = itemIds + $(this).attr("id") + ";";
            refreshInvoiceTable();
        }
    });

    $("#generateInvoice").click(function(){
        var urlGenerate="Home/GenerateInvoice";
        window.location.href=urlGenerate;
    });
});

function changeQuantity(id,value){
    if(itemIds.includes(id+"-")){
        var innerItemIds=itemIds.split(';');
        for(var index=0;index<innerItemIds.length;index++){
            if(innerItemIds[index].indexOf(id+"-")!=-1){
                var previousQuantity=innerItemIds[index].split("-")[1];
                itemIds=itemIds.replace(id+"-"+previousQuantity,id+"-"+value);
            }
        }
    }
    else
    {
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