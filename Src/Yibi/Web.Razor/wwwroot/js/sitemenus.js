var sitemenus = {
    init: function () {
        this.initData();
    },
    initData: function () {
        this.getSiteMenusByRootNodes("");
    },
    getSiteMenusByRootNodes: function (appId) {
        //var acc = $("#accUcMenu");
        //var data = { "appId": "" + appId + "" };
        var url = common.apiPath + '/Api/GetSiteMenusAsync';
        common.ajax(url, {}, 'GET', '', true, true, function (result) {
            if (result.SiteMenus) sitemenus.accInit($('#accUcMenu'), result.SiteMenus);
        });
    },
    accInit: function (acc, data) {
        //var smpMenu = $('#SitePaths>span');
        var hasSelected = false;
        for (var i in data) {
            //var isSelect = smpMenu.filter(':contains("' + data[i].Title + '")').length > 0;
            //if (isSelect) hasSelected = true;
            var isSelect = false;

            var treeCtId = 'treeCt' + i + '';
            acc.accordion('add', {
                selected: isSelect,
                title: data[i].Title,
                content: '<input type="hidden" value="' + data[i].Id + '" /><ul id="' + treeCtId + '" class="menus" style="margin-top:8px;"></ul>'
            });
        }
        if (!hasSelected) acc.accordion('select', 0);
    },
    onAccAdd: function (title, index) {
        console.log('onAccAdd');
        var t = $('#treeCt' + index + '');
        t.tree({
            onLoadSuccess: function (node, data) {
            },
            onClick: function (node) {
                var url = node.attributes.Url;
                if (url && url != '') {
                    sitemenus.openTab(node.text, url);
                    //window.location = url;
                }
            }
        })
    },
    onAccSelect: function (title, index) {
        console.log('title--' + title + '--url--' + index);
        var t = $('#treeCt' + index + '');
        var roots = t.tree('getRoots');
        if (roots && roots.length > 0) return;

        var currPanel = $('#accUcMenu').accordion('getPanel', index);
        var parentId = currPanel.panel('body').find('[type=hidden]:first').val();

        var data = { "parentId": "" + parentId + "" };
        var url = common.apiPath + '/Api/GetSiteMenusTreeByParentId';
        common.ajax(url, data, 'GET', 'application/x-www-form-urlencoded', true, true, function (result) {
            if (result.SiteMenusTree) {
                t.tree('loadData', result.SiteMenusTree);
            }
        });
    },
    openTab: function (title, url) {
        console.log('title--' + title + '--url--' + url);
        var $tabs = $('#tt');
        if ($tabs.tabs('exists', title)) {
            $tabs.tabs('select', title);
            var tab = $tabs.tabs('getSelected');
            tab.panel('open').panel('refresh');
        }
        else {
            url = url + "?_r=" + Math.random();
            var content = '<iframe scrolling="no" frameborder="0" src=" ' + url + '" style="width:100%;height:98%;padding-top:5px;"></ifrmae>';
            $tabs.tabs('add', {
                title: title,
                content: content,
                closable: true,
                cache: false,
                onBeforeLoad: function () {
                    common.onProgressStart();
                },
                onLoad: function () {
                    common.onProgressStop();
                },
                onClose: function (title, index) {
                    common.onProgressStop();
                }
            });
        }
        return false;
    }
}