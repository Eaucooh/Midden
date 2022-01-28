var canvas = document.getElementById("canvas");
var ctx = canvas.getContext("2d");
w = ctx.canvas.width = window.innerWidth;
h = ctx.canvas.height = window.innerHeight;

var resizeTimer;
window.onresize = function() {
  w = ctx.canvas.width = window.innerWidth;
  h = ctx.canvas.height = window.innerHeight;
  amplitude = h/2;
  topOffset = h/4;
  
  resizeTimer = setTimeout(function() {
    dots = [];
  }, 200);
};

dots = [];
maxSpeed = 5; // Maximum Particle Speed
minSpeed = 1; // Minimum Particle Speed
emitRate = 100; // Particle-Spawnrate in ms (1000ms = 1s)
emitNum = 2; // Particles spawned at once
radius = 4; // Particle Size (Slow Particles are bigger)
trail = 0.1; // Trail Length 0=infinite | 1=none
hue = 120; // Base Hue 0-360
hueRange = 20; // Hue Variation at spawn
hueRotate = 100; // Hue Rotation from Start to End
maxDots = 200; // Maximum Particles

// Don't touch these :D
amplitude = h/2;
topOffset = h/4;
frequency = .01;
maxAmp1 = 3;
minAmp1 = 1;
maxAmp2 = 3;
minAmp2 = 1;

var controls = new function() {
  this.maxSpeed = maxSpeed;
  this.minSpeed = minSpeed;
  this.emitRate = emitRate;
  this.emitNum = emitNum;
  this.radius = radius;
  this.trail = trail;
  this.hue = hue;
  this.hueRange = hueRange;
  this.hueRotate = hueRotate;
  this.maxDots = maxDots;
  
  this.redraw = function() {
    maxSpeed = controls.maxSpeed;
    minSpeed = controls.minSpeed;
    emitRate = controls.emitRate;
    emitNum = controls.emitNum;
    radius = controls.radius;
    trail = controls.trail;
    hue = controls.hue;
    hueRange = controls.hueRange;
    hueRotate = controls.hueRotate;
    maxDots = controls.maxDots;
    
    clearInterval(emitter)
    emitter = setInterval(emitDots, emitRate);
  }
}

var gui = new dat.GUI({resizable : false});
var f1 = gui.addFolder('Emitter');
var f2 = gui.addFolder('Particles');
var f3 = gui.addFolder('Colors');
f1.add(controls, "maxDots", 100, 1000).step(10).onChange(controls.redraw);
f1.add(controls, "emitRate", 50, 1000).step(10).onChange(controls.redraw);
f1.add(controls, "emitNum", 1, 30).step(1).onChange(controls.redraw);
f2.add(controls, "maxSpeed", 3, 5).onChange(controls.redraw);
f2.add(controls, "minSpeed", 1, 3).onChange(controls.redraw);
f2.add(controls, "radius", 2, 10).onChange(controls.redraw);
f2.add(controls, "trail", 0.02, 0.3).onChange(controls.redraw);
f3.add(controls, "hue", 0, 360).step(1).onChange(controls.redraw);
f3.add(controls, "hueRange", 0, 50).step(1).onChange(controls.redraw);
f3.add(controls, "hueRotate", 0, 360).step(1).onChange(controls.redraw);
f1.open();f2.open();f3.open();

function emitDots(x,y){
  if(dots.length<maxDots){
    for(var i=0; i<emitNum; i++){
      dots.push({
        x: -50,
        y: 0,
        h: Math.random()*((hue+hueRange)-(hue-hueRange))-(hue-hueRange),
        xv: Math.random()*(maxSpeed-minSpeed)+minSpeed,
        a1: Math.random()*(maxAmp1-minAmp1)+minAmp1,
        a2: Math.random()*(maxAmp2-minAmp2)+minAmp2
      });
    }
  }
}

function draw(){
  document.getElementById("count").innerHTML = "Particles: "+ dots.length;
  ctx.fillStyle = "rgba(0,0,0,"+trail+")";
  ctx.rect(0,0,w,h);
  ctx.fill();
  for(var i=0; i<dots.length; i++){
    ctx.beginPath();
    ctx.fillStyle = "hsla("+(dots[i].h+(dots[i].x/(w/hueRotate)))+", 100%, 50%, "+1+")";
    ctx.arc(dots[i].x, topOffset+dots[i].y, radius/(dots[i].xv/3), 0, Math.PI*2);
    ctx.fill();
    ctx.closePath();

    newY = Math.cos(dots[i].x * frequency) * amplitude / dots[i].a1 + amplitude / dots[i].a2;
    dots[i].x += dots[i].xv;
    dots[i].y = newY;
    
    if(dots[i].x>w+radius){
      dots.splice(i,1);
    }
  }
  requestAnimationFrame(draw);
}

emitter = setInterval(emitDots, emitRate);
draw();