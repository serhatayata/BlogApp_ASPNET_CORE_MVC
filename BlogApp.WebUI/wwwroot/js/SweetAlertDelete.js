var object = { status: false, ele: null };
function conFunction(ev) {
    var evnt = ev;
    if (object.status) { return true; }
    Swal.fire({
        title: 'Are you sure you want to delete?',
        text: "You cannot undo this action!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Delete',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            object.status = true;
            object.ele = evnt;
            evnt.click();
        }
    })
    return object.status;
};