var formatDate=(date)=> {
    var today = date;
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var hour = today.getHours();
    var Minute = today.getMinutes();
    var second = today.getSeconds();

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    if (hour < 10) {
        hour = '0' + hour;
    }
    if (Minute < 10) {
        Minute = '0' + Minute;
    }
    if (second < 10) {
        second = '0' + second;
    }
    var today = dd + '/' + mm + '/' + yyyy + ' ' + hour + ':' + Minute + ':' + second;


    return today;
}