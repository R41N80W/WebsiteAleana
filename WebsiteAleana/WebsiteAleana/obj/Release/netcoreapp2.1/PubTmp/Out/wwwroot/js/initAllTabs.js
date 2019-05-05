initAllTabs()

var content = document.getElementById('content')
//preventSelection(content)

function initAllTabs() {
    //alert("fdf")
    var div = document.getElementById('topnav')
    var elems = div.getElementsByTagName('LI')
    //alert(elems)
    //initTab(elems[0], 'main', null, null)
    //initTab(elems[1], 'nedvig', elems[0], 'main')
    //initTab(elems[2], 'auto', elems[1], 'nedvig')
    //initTab(elems[3], 'buss', elems[2], 'auto')
    //initTab(elems[4], 'act', elems[3], 'buss')
    //initTab(elems[5], 'obuch', elems[4], 'act')

    initTab(elems[0], 'main', null, null)
    initTab(elems[1], 'buss', elems[0], 'main')
    initTab(elems[2], 'act', elems[1], 'buss')
    initTab(elems[3], 'nedvig', elems[2], 'act')
    initTab(elems[4], 'auto', elems[3], 'nedvig')
    initTab(elems[5], 'obuch', elems[4], 'auto')
}

function getLink(html) {
    var ind = html.indexOf(">")
    var l = html.substring(9, ind - 1)
    l = l.replace("amp;", "")
    l = l.replace("amp;", "")
    l = l.replace("amp;", "")
    l = l.replace("amp;", "")
    l = l.replace("amp;", "")

    return l;
}
function initTab(tab, tabName, prevTab, prevTabName) {

    var footer = document.getElementById('hidden')

    //		var newdivCurrent = document.createElement('div');
    //        	newdivCurrent.setAttribute('id', tabName + '_current')
    //		footer.appendChild(newdivCurrent);

    //		var newdivLeftCurrent = document.createElement('div');
    //        	newdivLeftCurrent.setAttribute('id', tabName + '_leftCurrent')
    //		footer.appendChild(newdivLeftCurrent);


    if (prevTab != null) {
        if (prevTab.getAttribute('id') == prevTabName + '_current') {
            var newdivleftCurrentOver = document.createElement('div');
            newdivleftCurrentOver.setAttribute('id', tabName + '_leftCurrentOver')
            footer.appendChild(newdivleftCurrentOver);
        }
    }

    var newdivOver = document.createElement('div');
    newdivOver.setAttribute('id', tabName + '_over')
    footer.appendChild(newdivOver);

    //		var newdivNorm = document.createElement('div');
    //        newdivNorm.setAttribute('id', tabName + '_norm')
    //		footer.appendChild(newdivNorm);


    if (tab.getAttribute('id') == "current") {
        tab.setAttribute('id', tabName + '_current')
    }
    else if (prevTab != null) {
        if (prevTab.getAttribute('id') == prevTabName + '_current') {
            tab.setAttribute('id', tabName + '_leftCurrent')

            tab.onmouseover = function () {
                document.body.style.cursor = 'pointer'
                tab.setAttribute('id', tabName + '_leftCurrentOver')
            }

            tab.onmouseout = function () {
                document.body.style.cursor = 'default';
                tab.setAttribute('id', tabName + '_leftCurrent')
            }
        }
        else {
            tab.setAttribute('id', tabName + '_norm')

            tab.onmouseover = function () {
                document.body.style.cursor = 'pointer'
                tab.setAttribute('id', tabName + '_over')
            }

            tab.onmouseout = function () {
                document.body.style.cursor = 'default';
                tab.setAttribute('id', tabName + '_norm')
            }
        }
    }
    else {
        tab.setAttribute('id', tabName + '_norm')

        tab.onmouseover = function () {
            document.body.style.cursor = 'pointer'
            tab.setAttribute('id', tabName + '_over')
        }

        tab.onmouseout = function () {
            document.body.style.cursor = 'default';
            tab.setAttribute('id', tabName + '_norm')
        }
    }
    tab.onclick = function () {
        window.location = getLink(tab.innerHTML)
    }
}

function preventSelection(element) {
    var preventSelection = false;

    function addHandler(element, event, handler) {
        if (element.attachEvent)
            element.attachEvent('on' + event, handler);
        else
            if (element.addEventListener)
                element.addEventListener(event, handler, false);
    }
    function removeSelection() {
        if (window.getSelection) { window.getSelection().removeAllRanges(); }
        else if (document.selection && document.selection.clear)
            document.selection.clear();
    }
    function killCtrlA(event) {
        var event = event || window.event;
        var sender = event.target || event.srcElement;

        if (sender.tagName.match(/INPUT|TEXTAREA/i))
            return;

        var key = event.keyCode || event.which;
        if (event.ctrlKey && key == 'A'.charCodeAt(0))  // 'A'.charCodeAt(0) можно заменить на 65
        {
            removeSelection();

            if (event.preventDefault)
                event.preventDefault();
            else
                event.returnValue = false;
        }
    }

    // не даем выделять текст мышкой
    addHandler(element, 'mousemove', function () {
        if (preventSelection)
            removeSelection();
    });
    addHandler(element, 'mousedown', function (event) {
        var event = event || window.event;
        var sender = event.target || event.srcElement;
        preventSelection = !sender.tagName.match(/INPUT|TEXTAREA/i);
    });

    // борем dblclick
    // если вешать функцию не на событие dblclick, можно избежать
    // временное выделение текста в некоторых браузерах
    addHandler(element, 'mouseup', function () {
        if (preventSelection)
            removeSelection();
        preventSelection = false;
    });

    // борем ctrl+A
    // скорей всего это и не надо, к тому же есть подозрение
    // что в случае все же такой необходимости функцию нужно
    // вешать один раз и на document, а не на элемент
    addHandler(element, 'keydown', killCtrlA);
    addHandler(element, 'keyup', killCtrlA);
}