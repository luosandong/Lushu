(function () {
    function IndexPage(name) {
        this.name = name;
    }
    if (window.globalConfig.debug) {
        $.get('/data/books.json', function (data) {
            console.log(data);
        })
    } else {
        $.get('api/bookservice/list', function (data) {
            console.log(data);
        })
    }

}());