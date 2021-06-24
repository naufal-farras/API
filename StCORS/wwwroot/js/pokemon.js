$(document).ready(function () {
    $('#tablePoke').DataTable({
        ajax: {
            url: 'https://pokeapi.co/api/v2/pokemon/',
            dataSrc: 'results'
        },
        columns: [
            {
               
                "data": null, "sortable": true,
                "render": function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
    

            },
            {
                "data": 'name'
               
            },
            {
               "data": 'url'
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detail('${row['url']}')" data-toggle="modal" data-target="#exampleModalCenter">Detail</button>`;
                }

            }

        ]
    });
});


function detail(stringUrl) {
   
    $.ajax({
        url: stringUrl
    }).done((result) => {
        text2 = "";
        text2 += `

                    <div class="card" style="width: 29rem;">
                      <img class="card-img-top" src="${result.sprites.front_default}" alt="Card image cap">
                      <div class="card-body">
                        <h5 class="card-title">${result.name}</h5>
                      
                      </div>
                      <ul class="list-group list-group-flush">
                        <li class="list-group-item">Poke Id : ${result.id} ft </li>
                        <li class="list-group-item">Height : ${result.height} ft </li>
                        <li class="list-group-item">Weight1 : ${result.weight} </li>
                    
                      </ul>
                     
                    </div>

               
                       `;

        $('#modalPoke').html(text2);
    }).fail((error) => {
        console.log(error);
    });

}

