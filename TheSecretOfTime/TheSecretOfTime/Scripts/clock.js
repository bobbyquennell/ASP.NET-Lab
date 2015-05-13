function clock() {
    var d, h, m, s;
    d = new Date;
    h = 30 * ((d.getHours() % 12) + d.getMinutes() / 60);
    m = 6 * d.getMinutes();
    s = 6 * d.getSeconds();
    //move hands:
    setAttr('h-hand', h);
    setAttr('m-hand', m);
    setAttr('s-hand', s);
   

    setTimeout(clock, 1000);
}

function setAttr(id, val) {
    var v = 'rotate(' + val + ',150,150)';
    document.getElementById(id).setAttribute('transform', v);
};
window.onload = clock;


