/// <reference path="../routes/routes.js" />

myapp.controller('loginController', function ($scope, dbservices) {
    $scope.user = {
        uname: '',
        password: ''
    }

    $scope.loginn = function (udata) {
        console.log('sfsf',udata);
        dbservices.loginn(udata).then(function (data) {
            if (data.data == 1)
            {
                $scope.msg = "login successfull";
                $scope.user.uname = '';
                $scope.user.password = '';
            }
            else if (data.data == 0)
            {
                $scope.msg = "username password didn't matched";
                $scope.user.uname = '';
                $scope.user.password = '';
            }
            else {
                $scope.msg = "username password fields should be filled"
            }
        });
    }
});