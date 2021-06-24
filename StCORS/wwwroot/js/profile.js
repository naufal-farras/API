$(document).ready(function () {
     $('#tableProf').DataTable({
        ajax: {
             url: '/home/getsemuadata',
            dataSrc: ''
        },
        columns: [
            {
               
                "data": null, "sortable": true,
                "render": function (data, type, row, meta)
                {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
    
            },
            {
                "data": 'firstName'

            },
            {
                "data": 'email'
               
            },
            {
               "data": 'phone'
            },
            {
                "data": 'degree'
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `
                            <button type="button" class="btn btn-primary" onclick="detail('${row['nik']}')" data-toggle="modal" data-target="#exampleModalCenter">Detail</button>

                            <button type="button" class="btn btn-danger" onclick="del('${row['nik']}')" >Delete</button>
                            `;
                }

            }

        ]
    });
   
});


    //bootstrapValidate('#firstname', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#lastname', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#phone', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#birthdate', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#salary', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#password', 'min:8:password minimal 8 karakter');
    //bootstrapValidate('#email', 'email: masukan email yang valid dan belum pernah di pakai');
    //bootstrapValidate('#degree', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#gpa', 'required:Kolom tidak boleh kosong');
    //bootstrapValidate('#universityid', 'required:Kolom tidak boleh kosong');


function detail(stringUrl) { 
    $.ajax({
        url: '/home/GetProfilbyId/' + stringUrl,   
         type: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        //data: JSON.stringify(obj)
    }).done((result) => {

        $("#nik").val(result.nik);
        $("#firstname").val(result.firstName);
        $("#lastname").val(result.lastName);
        $("#phone").val(result.phone);
        $("#birthdate").val(result.birthDate.split("T")[0]);
        $("#salary").val(result.salary);
        $("#email").val(result.email);
        $("#password").val(result.password);
        $("#degree").val(result.degree);
        $("#gpa").val(result.gpa);
        $("#universityid").val(result.universityid);

        //buat alert pemberitahuan jika success
        //alert("Data Sukses");
        //Swal.fire(
        //    'Success !',
        //    'Data Berhasil Di Update',
        //    'success'
        //)
        //console.log(result);

        //text2 = "";
        ////console.log(result);
        //text2 += `
        //        <tr>
        //        <th> NIK : ${result.nik}</th>                 
        //        </tr>
        //         <tr>
        //           <th> Full Name : ${result.firstName} ${result.lastName} </th>
        //        <tr>
        //        <tr>
        //           <th> Email : ${result.email} </th>
        //        </tr>
        //        <tr>
        //        <th> Phone : ${result.phone}</th>                 
        //        </tr>              
        //           <tr>
        //        <th> Salary : ${result.salary}</th>                 
        //        </tr>

        //   `;
        //$('#modalProf').html(text2);
    }).fail((error) => {
        Swal.fire(
            'Failed !',
            'Data Gagal di Update',
            'error'
        )          
        //console.log(error);
    });

}


function insertProfile() {
   //if (e.some(e => e.email != null)) {
    //    bootstrapValidate('#email', 'email: email sudah digunakan');
    //}
    //else {
    //    bootstrapValidate('#email', 'email: email tidak boleh kosong');
    //}


    bootstrapValidate('#firstname', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#lastname', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#phone', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#birthdate', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#salary', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#email', 'email: email sudah digunakan');  
    bootstrapValidate('#password', 'min:8:password minimal 8 karakter');
    bootstrapValidate('#degree', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#gpa', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#universityid', 'required:Kolom tidak boleh kosong');
   
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
        obj.FirstName = $("#firstname").val();
        obj.LastName = $("#lastname").val();
        obj.Phone = $("#phone").val();
        obj.BirthDate = $("#birthdate").val();
        obj.Salary = $("#salary").val();
        obj.Email = $("#email").val();
        obj.Password = $("#password").val();
        obj.Degree = $("#degree").val();
        obj.GPA = $("#gpa").val();
        obj.UniversityId = $("#universityid").val();


        //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
        $.ajax({
            url:' https://localhost:44345/API/person/Register',
            type: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
                //'success': function (e) {
                //    if (e.some(e.email == null)) {
                //    }
                //}
            },
            data: JSON.stringify(obj)
      
        }).done((result) => {
        
            $('#tableProf').DataTable().ajax.reload();
            //buat alert pemberitahuan jika success
            //alert("Data Sukses");
            Swal.fire(
                'Success !',
                'Data Berhasil Di Tambahkan',
                'success'
            )    
            //console.log(result);
        }).fail((error) => {
            //alert pemberitahuan jika gagal
             
            Swal.fire(
                'Failed !',
                'Data Gagal di Tambahkan',
                'error'
            )    
            console.log(error);

          

            //alert("Data Gagal");
            console.log(error);
        })
       
}



function updateProfile() {

    bootstrapValidate('#firstname', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#lastname', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#phone', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#birthdate', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#salary', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#password', 'min:8:password minimal 8 karakter');
    //bootstrapValidate('#email', 'email: masukan email yang valid dan belum pernah di pakai');
    bootstrapValidate('#degree', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#gpa', 'required:Kolom tidak boleh kosong');
    bootstrapValidate('#universityid', 'required:Kolom tidak boleh kosong');

    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    obj.NIK = $("#nik").val();
    obj.FirstName = $("#firstname").val();
    obj.LastName = $("#lastname").val();
    obj.Phone = $("#phone").val();
    obj.BirthDate = $("#birthdate").val();
    obj.Salary = $("#salary").val();
    obj.Email = $("#email").val();
    obj.Password = $("#password").val();
    obj.Degree = $("#degree").val();
    obj.GPA = $("#gpa").val();
    obj.UniversityId = $("#universityid").val();


    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: 'https://localhost:44345/API/person/UpdateProfile',
        type: "PUT",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        $('#tableProf').DataTable().ajax.reload();
        //buat alert pemberitahuan jika success
        //alert("Data Sukses");
        Swal.fire(
            'Success !',
            'Data Berhasil Di Ubah',
            'success'
        )
        //console.log(result);
    }).fail((error) => {
        //alert pemberitahuan jika gagal
        Swal.fire(
            'Failed !',
            'Data Gagal di Ubah',
            'error'
        )
        bootstrapValidate('#email', 'email: email sudah digunakan');

        //alert("Data Gagal");
        console.log(error);
    })
    //console.log(obj);
}
  
function del(stringUrl) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44345/API/person/DeleteProfilbyId/' + stringUrl,
                type : "POST"
            }).done((result) => {
                //console.log(result);
                $('#tableProf').DataTable().ajax.reload();
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }).fail((error) => {
                Swal.fire(
                    'Failed !',
                    'Data Gagal di Hapus',
                    'error'
                )
                console.log(error);
            });
            
        }
    })
   

}



