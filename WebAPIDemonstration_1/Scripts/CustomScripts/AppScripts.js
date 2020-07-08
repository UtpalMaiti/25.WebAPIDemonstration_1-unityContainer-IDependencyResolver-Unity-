$(document).ready(function () {

    LoadEmployees();

    $("#btnGet").click(function () {

        $.ajax({
            type: 'GET',
            url: 'http://localhost:2012/api/EmployeeApi/' + $("#empId").val(),
            success: function (output) {
                bootbox.alert(JSON.stringify(output));
                console.log(output);

                        $("#newEmpDiv").show();
                        $("#employeeId").val(output.Id);
                        $("#employeeName").val(output.Name);
                        $("#employeeLocation").val(output.Location);
                        $("#employeeSalary").val(output.Salary);
                        $("#deptId").val(output.DeptId);
                        $("#btnCreate").hide();
                        $("#employeeId").attr("readonly", true);

                
            }
        });

    });

    $("#btnDelete").click(function () {

        var isConfirmed = confirm("Are you sure to Delete the Record ?");

        if (isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: 'http://localhost:2012/api/EmployeeApi/' + $("#empId").val(),
                success: function (output) {
                    if (output) {
                        alert('Record is Deleted Successfully');
                        console.log(output);

                        LoadEmployees();
                    }
                    else {
                        alert('No Record to Delete');
                        console.log(output);

                    }
                },
                error: function (info) {
                    alert(JSON.stringify(info));
                    console.log(info);

                }
            });

        }
    });

    $("h2").click(function () {
        $("#newEmpDiv").toggle();
    });

    $("#btnCreate").click(function () {

        var employee = {
            Id: $("#employeeId").val(),
            Name: $("#employeeName").val(),
            Location: $("#employeeLocation").val(),
            Salary: $("#employeeSalary").val(),
            DeptId: $("#deptId").val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:2012/api/EmployeeApi',
            data: $("#newEmpForm").serialize(),
            success: function (result) {
                console.log(result);
                if (result) {
                    alert('New Employee Record is Created Successfully');
                    $("#employeeId").val('');
                    $("#employeeName").val('');
                    $("#employeeLocation").val('');
                    $("#employeeSalary").val('');
                    $("#deptId").val('');
                    $("#newEmpDiv").hide();

                    //LoadEmployees();

                    $("#empData").append('<tr><td>' + employee.Id + '</td><td>' + employee.Name +
                        '</td><td>' + employee.Location + '</td><td>' + employee.Salary +
                        '</td><td>' + employee.DeptId + '</td></tr>');

                    $("#newEmpForm").empty();
                }
                else {
                    alert('Record Insertion Failed. Please try again');
                    console.log(result);

                }
            }
        });
    });

    $("#btnUpdate").click(function () {

        var employee = {
            Id: $("#employeeId").val(),
            Name: $("#employeeName").val(),
            Location: $("#employeeLocation").val(),
            Salary: $("#employeeSalary").val(),
            DeptId: $("#deptId").val()
        };

        console.log(employee);
        console.log($("#newEmpForm").serialize());
        $.ajax({
            type: 'PUT',
            url: 'http://localhost:2012/api/EmployeeApi',
            //data: $("#newEmpForm").serialize(),
            data: employee,
            success: function (result) {
                console.log(result);
                if (result) {
                    bootbox.alert('Employee Record is Updated Successfully');
                    //$("#employeeId").val('');
                    //$("#employeeName").val('');
                    //$("#employeeLocation").val('');
                    //$("#employeeSalary").val('');
                    //$("#deptId").val('');
                    $("#newEmpDiv").hide();

                    LoadEmployees();

                    //$("#empData").append('<tr><td>' + employee.Id + '</td><td>' + employee.Name +
                    //    '</td><td>' + employee.Location + '</td><td>' + employee.Salary +
                    //    '</td><td>' + employee.DeptId + '</td></tr>');

                    $("#newEmpDiv").hide();
                }
                else {
                    alert('Record Updation is Failed. Please try again');
                    console.log(result);

                }
            }
        });
    });
});

function LoadEmployees() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:2012/api/EmployeeApi',
        success: function (result) {
            console.log(result);

            $("#empData").empty();

            $.each(result, function (i, emp) {

                $("#empData").append('<tr><td>' + emp.Id + '</td><td>' + emp.Name +
                    '</td><td>' + emp.Location + '</td><td>' + emp.Salary + '</td><td>' +
                    emp.DeptId + '</td></tr>');

            });
        }
    });
}