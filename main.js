// JavaScript source code  
'use strict'  
$(document).ready(function ()  
{  
    getUserData();
});  
  
$('form').submit(function (e) {  
    e.preventDefault();  
    const data = {  
        FirstName: $('#firstName').val(),  
        LastName: $('#lastName').val(),  
        CNP: $('#cnp').val(),
        IDCardSerial: $('#idCardSerial').val(),
        IDCardNumber: $('#idCardNumber').val(),
        Address: $('#address').val(),
        BirthDate: $('#birthDate').val(),
        IssuanceDate: $('#issuanceDate').val(),
        ExpiryDate: $('#expiryDate').val()
    }  
  
    let tag = '<tr><td>' + data.FirstName + '</td>';  
    tag += '<td>' + data.LastName + '</td>';  
    tag += '<td>' + data.CNP + '</td>';
    tag += '<td>' + data.IDCardSerial + '</td>';
    tag += '<td>' + data.IDCardNumber + '</td>';
    tag += '<td>' + data.Address + '</td>';
    tag += '<td>' + data.BirthDate + '</td>';
    tag += '<td>' + data.IssuanceDate + '</td>';
    tag += '<td>' + data.ExpiryDate + '</td></tr>';
    $('table>tbody').append(tag);  
    const api = 'https://localhost:44354/api/tblUsers'  
    console.log(data);  
    $.post(api, { FirstName: data.FirstName, LastName:data.LastName, CNP:data.CNP,
    IDCardSerial:data.IDCardSerial, IDCardNumber:data.IDCardNumber, Address:data.Address,
    BirthDate:data.BirthDate, IssuanceDate:data.BirthDate, ExpiryDate:data.ExpiryDate });  
});  
  
function getUserData() {  
    const api = 'https://localhost:44354/api/tblUsers'
    var users;  
    $.getJSON(api).then(function (data) {  
        console.log(data);
        for (var i = 0, len = data.length; i < len; i++) {  
  
            $('table>tbody').append(createUser(data[i]));
            }
        }).catch(function (err) {  
            console.log(err);  
        });
}  
  
function createUser(user) {  
    let tag = `  
        <tr>  
            <td>  
                ${user.firstName}  
            </td>  
            <td>  
                ${user.lastName}  
            </td>  
            <td>  
               ${user.cnp}  
            </td> 
            <td>  
                ${user.idCardSerial}  
            </td>  
            <td>  
                ${user.idCardNumber}  
            </td>  
            <td>  
               ${user.address}  
            </td>   
            <td>  
                ${user.birthDate}  
            </td>  
            <td>  
               ${user.issuanceDate}  
            </td> 
            <td>  
                ${user.expiryDate}  
            </td>  
        </tr>  
    `;  
    return tag;
}