var common = {
    //apiPath: 'http://localhost/EIP/Api',
    //sitePath: 'http://localhost/EIP',
    apiPath:'http://localhost:5000',
    sitePath: 'http://10.0.0.54/EIP',
    getAuthFmInfo: function () {
        var data = { DeviceId: navigator.appName, Latlng: '', LoginId: '', Platform: 'PC' };
        //var sToken = common.GetCookie("Token");
        //if (sToken) data.Token = sToken;
        return data;
    },
    getWh: function (w, h) {
        var winw = $(window).width();
        var winh = $(window).height();
        if (w > 0) {
            if (winw < w) w = winw * 0.9;
        }
        else w = winw;
        if (h > 0) {
            if (winh < h) h = winh * 0.9;
        }
        else h = winh;

        return new Array(w, h);
    },
    getMainWh: function (w, h) {
        var winw = $('#pageMain').width();
        var winh = $('#pageMain').height();
        if (w > 0) {
            if (winw < w) w = winw * 0.9;
        }
        else w = winw;
        if (h > 0) {
            if (winh < h) h = winh * 0.9;
        }
        else h = winh;

        return new Array(w, h);
    },
    ajax: function (url, data, type, contentType, isProgress, isAlertErr, callback) {
        if (!type || type == '') type = "POST";
        if (!contentType || contentType == '') contentType = "application/json; charset=utf-8";
        if (!isProgress) isProgress = true;
        if (!isAlertErr) isAlertErr = true;
        $.ajax({
            url: url,
            type: type,
            data: data,
            cache: false,
            contentType: contentType,
            beforeSend: function () {
                if (isProgress) common.onProgressStart();
            },
            complete: function () {
                if (isProgress) common.onProgressStop();
            },
            success: function (result) {
                console.log('common.ajaxPost--result--' + JSON.stringify(result));
                if (result.ResCode != 1000) {
                    if (isAlertErr) $.messager.alert('系统提示', result.Msg, 'info');
                    return false;
                }
                if (typeof (eval(callback)) == 'function') {
                    callback(result);
                }
            }
        });
    },
    onProgressStart: function () {
        $('#dlgWaiting').dialog({
            closed: false,
            content: '<div class="datagrid-mask-msg" style="display:block;"></div>'
        });
    },
    onProgressStop: function () {
        $("#dlgWaiting").dialog('destroy');
    },
    messagerShow: function (title, msg) {
        $.messager.show({
            title: title,
            msg: msg,
            showType: 'slide',
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
    },
    dlgForm: function (dlgId, href, w, h, title, iconcls, onLoadFun, callback) {
        if ($("body").find("#" + dlgId + "").length == 0) {
            $("body").append("<div id=\"" + dlgId + "\" style=\"padding:10px;\"></div>");
        }
        var wh = common.getWh(w, h);
        $("#" + dlgId + "").dialog({
            title: title,
            width: wh[0],
            height: wh[1],
            closed: false,
            modal: true,
            iconCls: iconcls,
            buttons: [{
                id: 'btnSave_' + dlgId + '', text: '保存', iconCls: 'icon-save', handler: function () {
                    if (typeof (eval(callback)) == "function") {
                        callback();
                    }
                }
            }, {
                id: 'btnCancel_' + dlgId + '', text: '取消', iconCls: 'icon-cancel', handler: function () {
                    $('#' + dlgId + '').dialog('close');
                }
            }],
            href: common.sitePath + href,
            onLoad: function () {
                if (typeof (eval(onLoadFun)) == "function") {
                    onLoadFun();
                }
            }
        })
    }
}