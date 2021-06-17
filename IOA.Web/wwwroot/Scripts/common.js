/***public script***/

layui.use(['form'], function () {
    var form = layui.form;
    var layer = layui.layer;

    layui.jquery.ajaxSetup({ //针对IE浏览器全局ajax禁用缓存
        cache: false
    });

    layui.jquery(document).ajaxComplete(function (event, xhr, options) {
        if (xhr.getResponseHeader('sessionstate') == 'timeout') {
            layer.alert('登录超时，请重新登录！', { title: '系统提示', icon: 2 }, function () {
                top.location.href = '/Home/Login';
            })
        }
    })

    form.verify({ //重新定义手机号和邮箱验证，不为空时才验证
        cusphone: function (value, item) {
            if (value.replace(/(^\s*)|(\s*$)/g, '') != '' && !new RegExp('^1(3[0-9]|5[0-35-9]|8[025-9])\\d{8}$').test(value)) {
                return '请输入正确的手机号';
            }
        },
        cusemail: function (value, item) {
            if (value.replace(/(^\s*)|(\s*$)/g, '') != '' && !new RegExp('^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$').test(value)) {
                return '邮箱格式不正确';
            }
        },
        number_z: function (value, item) {
            if (!new RegExp('^(0|[1-9][0-9]*)$').test(value)) {
                return '请输入大于或等于0的整数';
            }
        },
        number_n: function (value, item) {
            if (!new RegExp('^[0-9]*[1-9][0-9]*$').test(value)) {
                return '只允许输入数字';
            }
        },
        letter: function (value, item) {
            if (!new RegExp('^[a-zA-Z]+$').test(value)) {
                return '只允许输入英文字母';
            }
        }
    })
})

var com = {
    //有loading等待效果
    getAjax: function (url, data, callBack, dtype, method) {
        var type = 'post';
        var dataType = 'text';
        if (dtype != null) dataType = dtype;
        if (method != null) type = method;
        var idx;
        layui.jquery.ajax({
            url: url,
            type: type,
            data: data,
            dataType: dataType,
            beforeSend: function () {
                idx = layer.load(2, { shade: [0.1, 'transparent'] });
            },
            success: callBack,
            complete: function (xhr) {
                layer.close(idx);
                if (xhr.getResponseHeader('sessionstate') == 'timeout') {
                    layer.alert('登录超时，请重新登录！', { title: '系统提示', icon: 2 }, function () {
                        top.location.href = '/Home/Login';
                    })
                }
            }
        })
    },
    //无loading等待效果
    getAjax1: function (url, data, callBack, dtype, method) {
        var type = 'post';
        var dataType = 'text';
        if (dtype != null) dataType = dtype;
        if (method != null) type = method;
        layui.jquery.ajax({
            url: url,
            type: type,
            data: data,
            dataType: dataType,
            success: callBack,
        })
    },
    load: function (url) {
        var $ = layui.$;
        var date1 = new Date();
        layui.jquery.ajax({
            url: url,
            type: 'get',
            beforeSend: function () {
                $('body').append(com.loading);
            },
            success: function (data) {
                var timediff = new Date().getTime() - date1.getTime();
                setTimeout(function () {
                    $('.page-shade,.page-loading').remove();
                    $('.layui-body').html(data);
                }, timediff <= 500 ? 500 : 0)
            },
            complete: function (xhr) {
                if (xhr.getResponseHeader('sessionstate') == 'timeout') {
                    layer.alert('登录超时，请重新登录！', { title: '系统提示', icon: 2 }, function () {
                        top.location.href = '/Home/Login';
                    })
                }
            }
        })
    },
    loadiframe: function (url) {
        var $ = layui.$;
        $('body').append(com.loading);
        var date1 = new Date();
        var timediff = new Date().getTime() - date1.getTime();
        setTimeout(function () {
            $('.page-shade,.page-loading').remove();
         
            var myiframe = document.createElement("iframe");
            myiframe.src = url;
            myiframe.style = "width:100%;height:100%";
            myiframe.frameBorder = 0;
            myiframe.scrolling = "auto";
            $('.layui-body').html("");
            $('.layui-body').append(myiframe);
        }, timediff <= 500 ? 500 : 0)
    },
    get: function (url, callBack) {
        layui.jquery.ajax({
            url: url,
            type: 'get',
            success: callBack,
            complete: function (xhr) {
                if (xhr.getResponseHeader('sessionstate') == 'timeout') {
                    layer.alert('登录超时，请重新登录！', { title: '系统提示', icon: 2 }, function () {
                        top.location.href = '/Home/Login';
                    })
                }
            }
        })
    },
    //获取查询条件
    getWhere: function () {
        var $ = layui.$;
        var obj = {};
        $('#search input,#search select').each(function () {
            if ($(this).attr('name')) {
                obj[$(this).attr('name')] = $(this).val();
            }
        })
        return obj;
    },
    //格式化日期 yyyy-MM-dd
    formatDate: function (value) {
        if (value) {
            return value.substr(0, 10);
        }
        else {
            return '';
        }
    },
    //格式化时间 yyyy-MM-dd hh:mm:ss
    formatTime: function (value) {
        if (value) {
            return value.substr(0, 19).replace('T', ' ');
        }
        else {
            return '';
        }
    },
    limit: 10,
    limits: [10, 20, 30, 40, 50],
    delSuccess: '<i class="layui-icon layui-icon-ok-circle"/> 删除成功！',
    saveSuccess: '<i class="layui-icon layui-icon-ok-circle"/> 保存成功！',
    exportSuccess: '<i class="layui-icon layui-icon-ok-circle"/> 导出成功！',
    reSuccess: '<i class="layui-icon layui-icon-ok-circle"/> 重置成功！',
    fpSuccess: '<i class="layui-icon layui-icon-ok-circle"/> 分配成功！',
    loading: '<div class="page-shade"></div><div class="page-loading"><div class="page-animate"><span class="circle"></span><span class="circle"></span><span class="circle"></span><span class="circle"></span></div></div>'
}
