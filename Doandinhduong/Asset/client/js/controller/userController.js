var user = {
    init: function () {
        user.registerEvents();
       
    },
    registerEvents: function () {
        $('.btn-capnhat').off('click').on('click', function (e) {
            e.preventDefault();
            var username = $('#idnguoidung').val();            
            var tuoi = $('#txtAge').val();
            var gioitinh = $('#txtGender').val();
            var cannang = $('#txtWeight').val();
            var chieucao = $('#txtHeight').val();
            var kieunguoi = $('#txtActivity').val();
            $.ajax({
                url: "/Nguoidung/Changethongtin",
                data: {
                    username: username,
                    tuoi: tuoi,
                    gioitinh: gioitinh,
                    cannang: cannang,
                    chieucao: chieucao,
                    kieunguoi: kieunguoi
                },
                dataType: "json",
                type: "POST",
                success: function (response) {
                   
                    if (response.status == true) {
                        
                        alert('Save thành công');
                        location.reload();
                        
                    }
                    
                }
            });
        });
    },
   
    

}
user.init();
