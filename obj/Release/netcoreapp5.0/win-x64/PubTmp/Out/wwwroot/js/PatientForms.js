// Function to GeneratePdf
function GeneratePdf() {
	var element = document.getElementById('form-print');
	html2pdf(element);
}



$(document).ready(function () {


    function formTime() {
        var today = new Date();
        var d = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
        var date = new Date();
        var lblDateTime = document.getElementById("lblDateTime");
        lblDateTime.innerHTML = time;
    }

   

    //Autofill disable
    function OnClientLoad(sender, args) {
        disableAutoFill(sender);
    }

    function disableAutoFill(control) {
        function focusHandler(ev) {
            this.originalName = this.name;
            this.name = new Date().toString();
        }
        function blurHandler(ev) {
            this.name = this.originalName;
        }

        if (Telerik.Web.UI.RadComboBox && control instanceof Telerik.Web.UI.RadComboBox) {
            $telerik.$(control.get_inputDomElement()).on({
                focus: focusHandler,
                blur: blurHandler
            });
        } else if (Telerik.Web.UI.RadTextBox && control instanceof Telerik.Web.UI.RadTextBox) {
            $telerik.$(control.get_element()).on({
                focus: focusHandler,
                blur: blurHandler
            });
        }
    }

    
});



