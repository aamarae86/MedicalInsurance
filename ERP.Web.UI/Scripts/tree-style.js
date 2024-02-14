//$(function () {

//  //let data = [
//  //     { "id" : "1", "parent" : "#", "text" : "مصر" },
//  //     { "id" : "2", "parent" : "#", "text" : "الصين" },
//  //     { "id" : "3", "parent" : "#", "text" : "المغرب" },
//  //     { "id" : "4", "parent" : "#", "text" : "استراليا" },
//  //     { "id" : "1-1", "parent" : "1", "text" : "القاهرة" },
//  //     { "id" : "1-1-1", "parent" : "1-1", "text" : "مدينة نصر" },
//  //     { "id" : "1-1-2", "parent" : "1-1", "text" : "السيدة زينب" },
//  //     { "id" : "1-2", "parent" : "1", "text" : "الاسكندرية" },
//  //     { "id" : "1-3", "parent" : "1", "text" : "الجيزة" },
//  //     { "id" : "2-1", "parent" : "2", "text" : "بكين" },
//  //     { "id" : "2-2", "parent" : "2", "text" : "شنجهاي" },
//  //     { "id" : "2-3", "parent" : "2", "text" : "جيانغسو" },
//  //     { "id" : "4-1", "parent" : "4", "text" : "سيدني" },
//  //  ];
//  //  createJSTree(data);

//    $("#search").keyup(function () {
//        var searchString = $(this).val();
//        $('#jstree').jstree('search', searchString);
//    });

//    $('#jstree').on("changed.jstree", function (e, data) {
//      var path = data.instance.get_path(data.node,'/');
//      alert(`This id =${data.node.id} and the text =${data.node.text} and path = ${path}`)
//      console.log(data.node,data);
//      console.log('Selected: ' + path);
//    });


//    function createJSTree(data) {
//      $('#jstree').jstree({
//          "core": {
//            "check_callback" : true,
//              'data': data,

//          },
//          "plugins": ["search"],
//          "search": {
//              "case_sensitive": false,
//              "show_only_matches": true
//          }
//      });
//    }


//});
