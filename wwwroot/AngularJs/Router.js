/// <reference path="angular-ui-router.js" />
/// <reference path="angular.js" />

var employeeModule = angular
    .module("Employee", ["ui.router"])
    .config(function ($stateProvider, $urlRouterProvider) {
     //   $urlRouterProvider.otherwise("/Employees");
        $stateProvider
            .state("Employees", {
                url: "/Employees",
                templateUrl: "ListOfEmployee.html",
                controller: "getEmployee",
                controllerAs: "employeecontrollerCtrl"

            })
            .state("EmployeeById", {
                url: "Employee",
                templateUrl: "EmployeeById.html",
                controller:"EmployeeByIdCtrl"
            })
       
    })
    .controller("getEmployee", function ($scope, $http) {
        $scope.updateEmployee = function (id, fristName, secondName, gender, address, matrial_staus, dob, salary) {
                $scope.EmployeeID = id,
                $scope.FristName = fristName,
                $scope.SecondName = secondName,
                $scope.Gender = gender,
                $scope.Address = address,
                $scope.MaritalStaus = matrial_staus,
                $scope.dob = dob,
                $scope.salary = salary
        }
        $http.get('http://localhost:64535/api/Employee/')
            .then(function (response) {
                $scope.employee = response.data;
            });
    })
    .controller("SaveEmployee", function ($scope, $http) {
        $scope.postdata = function (fristName, secondName, gender, DateofBirth, Marital, Salary, address) {
            var data = {
                fristName: $scope.fristName,
                secondName: $scope.secondName,
                gender: $scope.gender,
                dob: $scope.DateofBirth,
                matrial_staus: $scope.Marital,
                salary: $scope.Salary,
                address: $scope.address
            };
            console.log(data);
            $http.post("http://localhost:64535/api/Employee", data)
                .then(function (data) {
                    $scope.PostDataResponse = data;
                    console.log(data.data);
                 
                })
                .catch(function (err) {
                    console.log("err is ", err);
                })
        }
    })
    .controller("updateEmployee", function ($scope, $http, $state, $location) {
        $scope.UpdateEmployee = function (EmployeeID, FristName, SecondName, Gender, dob, MaritalStaus, salary, Address) {
            var data = {
                id: $scope.EmployeeID,
                fristName: $scope.FristName,
                secondName: $scope.SecondName,
                gender: $scope.Gender,
                dob: $scope.dob,
                matrial_staus: $scope.MaritalStaus,
                salary: $scope.salary,
                address: $scope.Address
            }; console.log(data.id);
            console.log(data)
            $http.put('http://localhost:64535/api/Employee/'+data.id,data)
                .then(function (data) {
                    console.log(data.data);
                    $location.path("Employees");
                    $state.reload();
               });
        }
    })
.controller("DeleteEmployeeById", function ($scope, $http) {

    $scope.DeleteEmployee = function (id) {
        $http.delete('http://localhost:64535/api/Employee/' + id).then((data) => {
            console.log('data', data)
        })
            .catch((err) => {
            console.log('error')
        })
    }
})
    .controller("EmployeeByIdCtrl", function ($scope, $http) {
        $scope.getEmployeeID = function (id) {
            $scope.id = id;
            console.log($scope.id);
            $http.get("http://localhost:64535/api/Employee/"+id)
                .then(function (response) {
                    $scope.Data = response.data;
                    console.log(response.data);
                });
         }
    })
    
   