var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#productTable').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%"},
            {
                "data": "id",
                "render": function (data) {
                    return `
                         <td>
                             <div class="w-55 btn-group"  role="group">
                                 <a href="/Admin/Product/Upsert?id=${data}" 
                                    class=" = btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit</a>
                             </div>
                         </td>
                 
                         <td>
                             <div class="w-55 btn-group" role="group">
                                 <a  
                                    class=" = btn btn-danger"><i class="bi bi-trash-fill"></i> Delete</a>
                             </div>
                         </td>
                     `
                },
                "width": "15%"
            },

        ]
    });
}
