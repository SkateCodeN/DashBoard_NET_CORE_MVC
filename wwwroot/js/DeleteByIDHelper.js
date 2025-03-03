// By the powers that be, it is a pain to simply implement 
// a delete button within asp.net aka a simple function as we
// did to just get a single maintenance card


function deleteItem(id){
    if(confirm("Are you sure you want to delete this item?")){
        fetch('/maintenance/' + id , {
            method: 'DELETE'
        })
        .then(response => {
            if(response.ok){
                location.reload();
            }
            else{
                alert("Error deleting items.")
            }
        })
        .catch(error => {
            console.error("Error sending delete request", error)
        });
    }
}