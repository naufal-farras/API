// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { error } = require("jquery");

// Write your JavaScript code.
//var judul = document.getElementById('title');
//judul.style.color = 'salmon';
//judul.style.backgroundColor = 'lightgreen';

//var p = document.getElementsByTagName('p');
//for (var i = 0; i < p.length; i++) {
//    p[i].style.color = 'green';
//}

//var p1 = document.getElementsByClassName('pa')[0];
//p1.style.color = 'red';

//var query = document.querySelector('section#b .a ul li');
//var tampil = query.innerHTML;
//query.addEventListener('mouseover', function ()
//{
//    query.innerHTML = 'Mouse Datang';
//    query.style.backgroundColor = 'red';

//});

//query.addEventListener('mouseleave', function ()
//{
//    query.innerHTML = tampil;
//    query.style.backgroundColor = 'white';

//});
//var text1 = document.getElementsByClassName('text1');

//if ($("#cektext1").prop('checked', true))
//{
//    var text1 = document.getElementById('text1');
//    var button = document.getElementById('button');
//    button.addEventListener('click', function () {
//        text1.style.color = 'red';
//    });
//}
//else if ($("#cektext1").prop('checked', false)) {
//    var text1 = document.getElementById('text1');
//    var button = document.getElementById('button');
//    button.addEventListener('click', function () {
//        text1.style.color = 'blue';
//    });
//}


//}
//if ($("#cektext2").prop('checked', true)) {
//    var text1 = document.getElementById('text2');
//    var button = document.getElementById('button');
//    button.addEventListener('click', function () {
//        text1.style.color = 'red';
//    });
//}

//$('buttontes').on('click', function (e) {
//    e.preventDefault;
//});
//$(document).ready(function () {
//    //console.log("ready!");

//function check() {

//    var text1 = document.getElementById('text1');

//    if ($('#cektext1').is('checked')) {
//        $('#cektext1').attr('checked', true); //untuk melakukan check
//        text1.style.color = 'blue';
//        console.log("1");

//    } else {
//        $('#cektext1').attr('checked', false); //untuk melakukan uncheck
//        text1.style.color = 'red';
//        console.log("2");


//    }
//    }
//});


//const animals = [
//    { name: "tom", species: "cat", class: { name: 'mamalia' } },
//    { name: "chika", species: "cat", class: { name: 'mamalia' } },
//    { name: "oshi", species: "cat", class: { name: 'mamalia' } },
//    { name: "heli", species: "dog", class: { name: 'mamalia' } },
//    { name: "garfield", species: "cat", class: { name: 'mamalia' } },
//    { name: "garry", species: "snail", class: { name: 'invertebrata' } },
//    { name: "dani", species: "snail", class: { name: 'invertebrata' } },
//    { name: "leri", species: "snail", class: { name: 'invertebrata' } },
//    { name: "cakra", species: "snail", class: { name: 'invertebrata' } },

//];
////tampil data animals
//console.log(animals);

////merubah isi object class.name "invertebrata" menjadi "nonmamalia"
//let tampil = [];
//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].class.name == 'invertebrata') {
//        animals[i].class.name = 'nonmamalia';
//        tampil.push(animals[i]);
//    }
//}
//console.log(tampil);

////nampilin data species "cat" manuall
//let cat = [];
//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].species == 'cat') {
//        cat.push(animals[i]);
//    }
//}
//console.log(cat);

////nampilin data species "dog" using filter
//const dog = animals.filter(animal => animal.species == 'dog');
//console.log(dog);

$.ajax({
    url:'https://swapi.dev/api/people/'
  
}).done((result) => {
  
   text = "";
    $.each(result.results, function (key, val) {
       
        text += `<tr>
                   <td> ${val.name}</td>
                   <td> ${val.height} Cm </td>
                   <td> ${val.gender}</td>
                   <td>
<button type="button" class="btn btn-primary" onclick="detail('${val.url}')" data-toggle="modal" data-target="#exampleModalCenter">Detail</button></td>
                 </tr>`;
    })

    $('#tableSW').html(text);
}).fail((error) => {
    console.log(error);
});

function detail(stringUrl) {
    var split = stringUrl.split('/');
    $.ajax({
        url: 'https://swapi.dev/api/people/' + split[5]+'/'       
    }).done((result) => {           
            text2 = "";        
            text2 += `<h4>Name         : ${result.name}</h4>
                      <h4>Skin Color   : ${result.skin_color}</h4>
                      <h4>Height       : ${result.height} </h4>`;
    
        $('#modalSW').html(text2);
    }).fail((error) => {
        console.log(error);
    });

}



