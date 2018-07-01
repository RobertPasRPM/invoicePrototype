$(document).ready(function(){
    $(".mdc-list-item").click(function(){
        if($(this).hasClass("mdc-list-item--selected")){
            $(this).removeClass("mdc-list-item--selected")
        }
        else{
            $(this).addClass("mdc-list-item--selected");
            var itemId = $(this).attr("id");
            $.ajax({
                url: 'Home/InvoiceTable?itemId=' + itemId,
                success: function (response) {               
                    $("#selectedItems").append(response);
                    }
                });
        }
    });
});