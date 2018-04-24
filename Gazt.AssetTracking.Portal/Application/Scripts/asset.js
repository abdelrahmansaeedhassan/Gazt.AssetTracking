function populate(frm, data) {
    $.each(data, function (key, value) {
        var ctrl = $('[name=' + key + ']', frm);
        switch (ctrl.prop("type")) {
            case "date":
                var date = new Date(parseInt(value.substr(6)))
                var day = ("0" + date.getDate()).slice(-2);
                var month = ("0" + (date.getMonth() + 1)).slice(-2);
                var today = date.getFullYear() + "-" + (month) + "-" + (day);
                ctrl.val(today);
               
                break;
            case "radio": case "checkbox":
                ctrl.each(function () {
                    if ($(this).attr('value') == value) $(this).attr("checked", value);
                });
                break;
            default:
                ctrl.val(value);
        }
    });
}
function modify(id) {
   
    $.ajax({
        url: "/Asset/Find?id=" + id
    }).done(function (data) {
      
       
        populate('#form-data', data);
        
        $.ajax({
            url: "/Asset/FindZones?locationId=" + data.LocationId
        }).done(function (result) {
            var _options = "<option>[|[Choose]|]</option>";
            $.each(result, (index, zone) => {
                _options += `<option value=${zone.Id}>${zone.Name}</option>`;
            })
            $("#ZoneId").html(_options);
            $('#ZoneId').val(data.ZoneId);
            })
        
        $("#responsive").modal('show');
    })
}
function del(id) {
    var _confirm = confirm('[|[Are you sure ?]|]');
    if (_confirm) {
        $.ajax({
            url: "/Asset/Delete?id=" + id
        }).done(function (result) {
            if (result.Type = "success") {
                load();
                toastr.success(result.Message, "[|[PROCESS DONE]|]");
            }

            else
                toastr.error(result.Message, "[|[PROCESS DONE]|]");

        })
    }
  
}
function load() {
    if ($("#tblAssets").hasClass("dataTable")) {
        $('#tblAssets').dataTable().fnDestroy();
    }
    $('#tblAssets').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "paging": true,
        "pageLength": 25,
        "pagingType": "full_numbers",
        "ajax": {
            "url": "/Asset/FindAll",
            "type": "POST",
            "datatype": "json",
            "complete": function (result) {
                news = result.responseJSON.data;
            }
        },

        "columns": [

            {
                "name": "SerialNumber",
                "data": "SerialNumber"
            },
            {
                "name": "EPC",
                "data": "Epc"
            },
            {
                "name": "Model",
                "data": "ModelName"
            },
            {
                "targets": 3,
                "width": 50,
                "data": "ManufactureDate",
                "render": function (data, type, obj, meta) {
                    var date = new Date(parseInt(obj.ManufactureDate.substr(6)))
                    return `<p>${formatDate(date)}</p>`;
                },
            },
            {
                "targets": 4,
                "width": 50,
                "data": "PurchaseDate",
                "render": function (data, type, obj, meta) {
                    var date = new Date(parseInt(obj.PurchaseDate.substr(6)))
                    return `<p>${formatDate(date)}</p>`;
                },
            }
            ,
            {
                "name": "Zone",
                "data": "ZoneName"
            }
            ,
            {
                "name": "PrintedDate",
                "data": "PrintedDate"
            }
            ,
            {
                "name": "IsPrinted",
                "data": "IsPrinted"
            }
            ,
            {
                "name": "IsAssigned",
                "data": "IsAssigned"
            }


        ],
        "columnDefs": [


            {
                "targets": 9,
                "width": 50,
                "data": "Id",
                "render": function (data, type, assetObj, meta) {
                    return " <span class='fa fa-pencil Edit' onclick ='modify(" + data + ")' ></span >";
                },

            },
            {
                "targets": 10,
                "data": "Id",
                "width": 50,
                "render": function (id, type, newsObj, meta) {

                    return "<span class='fa fa-trash delete' onclick='del(" + id + ")'></span>";
                },
            },
            {
                "targets": 11,
                "data": "Id",
                "width": 50,
                "render": function (data, type, newsObj, meta) {

                    return "<span class='fa fa-suitcase assign' onclick='assign(" + data + ")'></span>";
                },
            }
        ]
    });
}
$(() => {
    $.validator.addMethod("valueNotEquals", function (value, element, arg) {
        return arg !== value;
    }, "Value must not equal arg.");
    $("#form-data").validate({
            rules: {
                SerialNumber: {
                    required: true
                },
                Epc: {
                    required: true
                },
                LocationId: {
                    required: true,
                    valueNotEquals: "[|[Choose]|]"
                },
                ModelId: {
                    required: true,
                    valueNotEquals: "[|[Choose]|]"
                },
                ZoneId: {
                    required: true,
                    valueNotEquals: "[|[Choose]|]"
                },
                ManufactureDate: {
                    required: true
                },
                PurchaseDate: {
                    required: true
                }
            },
            messages: {
                SerialNumber: {
                    required: "[|[Please Enter Serial Number]|]"
                },
                Epc: {
                    required:"[|[Please Enter Epc]|]"
                },
                LocationId: {
                    required: "[|[Please Select Location]|]",
                    valueNotEquals:"[|[Please Select Location]|]"
                },
                ModelId: {
                    required: "[|[Please Select Model]|]",
                    valueNotEquals: "[|[Please Select Model]|]"
                },
                ZoneId: {
                    required: "[|[Please Select Zone]|]",
                    valueNotEquals: "[|[Please Select Zone]|]"
                },
                ManufactureDate: {
                    required:"[|[Please Enter Manufacture Date]|]"
                },
                PurchaseDate: {
                    required: "[|[Please Enter Purchase Date]|]"
                }

            },
            errorElement: "em",
            errorPlacement: function (error, element) {
                error.addClass("help-block");
                if (element.prop("type") === "checkbox") {
                    error.insertAfter(element.parent("label"));
                } else {
                    error.insertAfter(element);
                }
            },
            highlight: function (element, errorClass, validClass) {
                $(element).parents(".col-sm-5").addClass("has-error").removeClass("has-success");
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).parents(".col-sm-5").addClass("has-success").removeClass("has-error");
            },
            submitHandler: function (form) {
                debugger;
                 $.ajax({
            url: "/Asset/Save",
            data: $('#form-data').serialize(),
            type: "POST"
        }).done(function (result) {
            if (result.Type == "success") {
                toastr.success(result.Message, "[|[PROCESS DONE]|]");
                load();
                $("#responsive").modal('hide');
            }
            else
                toastr.error(result.Message, "[|[PROCESS Error]|]");
                })
                return false;
            }
        });
    $('#btnAddNew').click(function () {
        document.getElementById("form-data").reset();
        $("#responsive").modal('show');
        return false;
    }) 
    $("#LocationId").change(function () {
        var location = $("#LocationId").val();
        $.ajax({
            url: "/Asset/FindZones?locationId=" + location
        }).done(function (result) {
            var _options = "<option>[|[Choose]|]</option>";
            $.each(result, (index, zone) => {
                _options += `<option value=${zone.Id}>${zone.Name}</option>`;
            })
            $("#ZoneId").html(_options)
        })
    })
    load();
   
})