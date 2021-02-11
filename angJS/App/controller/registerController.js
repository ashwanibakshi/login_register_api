/// <reference path="../routes/routes.js" />

myapp.controller('registerController', function ($scope,dbservices) {
    $scope.user = {
        uname: '',
        password: ''
    }
    $scope.msg=false;
    $scope.regist = function (udata) {
        dbservices.register(udata).then(function (data) {
            if (data.data == 0) {
                $scope.msg = "user already registered";
            }
            else if (data.data == 1) {
                $scope.msg = "user successfully registered";
                $scope.user.uname = '';
                $scope.user.password = '';
            }
            else {
                $scope.msg = "username password fields should be filled";
              
            }
        });
            
    }
});