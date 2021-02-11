/// <reference path="../routes/routes.js" />
myapp.factory('dbservices', function ($http) {

    var url = "http://localhost:50115/api/default"
    var dbServ = {};
    var returnData;
    dbServ.register = function (udata) {
       return $http.post(url + '/RegisterUser', udata, { 'Content-Type': 'application/json' }).then(function (data) {
           console.log('dataa', data);
           return data;
       }).catch(function (err) {
           console.log(err)
           return err;
       });
    }
    ,
   dbServ.loginn = function (udata) {
       return $http.post(url + '/LoginUser', udata, { 'Content-Type': 'application/json' }).then(function (data) {
           console.log(data)
           return data;
       }).catch(function (err) {
           console.log(err);
           return err;
       });
   }
    return dbServ;
});