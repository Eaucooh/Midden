class Particle {
  constructor() {
    this.x = Math.random() * w;
    this.y = Math.random() * h;
    this.angle = Math.random() * Math.PI * 2;
  }

  move() {
    let zoom = 70;
    let stepSize = 0.5;
    let x = Math.floor(this.x);
    let y = Math.floor(this.y);
    let index = y * w + x;
    let isInside = index < imageBuffer.length && imageBuffer[index];
    if (isInside) {
      let strength = 1;
      let xn = simplex.noise3D(this.x / zoom, this.y / zoom, ticker + 4000) * strength;
      let yn = simplex.noise3D(this.x / zoom, this.y / zoom, ticker + 8000) * strength;
      this.x += xn;
      this.y += yn;
    } else {
      this.angle += (Math.random() - 0.5) * 0.5;
      this.x += Math.cos(this.angle) * stepSize;
      this.y += Math.sin(this.angle) * stepSize;
    }

    if (this.x < 0) this.x = w;
    if (this.x > w) this.x = 0;
    if (this.y < 0) this.y = h;
    if (this.y > h) this.y = 0;
  }

  draw() {
    ctx.fillRect(this.x, this.y, 1, 1);
  }}


let canvas;
let ctx;
let w, h;
let imageBuffer;
let particles;
let ticker;
let simplex;

function setup() {
  ticker = 0;
  simplex = new SimplexNoise();canvas = document.querySelector("#canvas");
  ctx = canvas.getContext("2d");
  reset();
  window.addEventListener("resize", reset);
}

function setupParticles() {
  particles = [];
  let nrOfParticles = w * h / 40;
  for (let i = 0; i < nrOfParticles; i++) {
    particles.push(new Particle());
  }
}

function reset() {
  w = canvas.width = window.innerWidth;
  h = canvas.height = window.innerHeight;
  storeHeartInBuffer();
  setupParticles();
  ctx.fillRect(0, 0, w, h);
}

function draw() {
  requestAnimationFrame(draw);
  ctx.fillStyle = "rgba(0, 0, 0, 0.05)";
  ctx.fillRect(0, 0, w, h);
  ctx.fillStyle = "red";
  particles.forEach(p => {
    p.move();
    p.draw();
  });
  ticker += 0.014;
}

function storeHeartInBuffer() {
  ctx.beginPath();
  for (let angle = 0; angle < Math.PI * 2; angle += 0.01) {
    let r = Math.min(w, h) * 0.025;
    let x = r * 16 * Math.pow(Math.sin(angle), 3);
    let y = -r * (13 * Math.cos(angle) - 5 * Math.cos(2 * angle) - 2 * Math.cos(3 * angle) - Math.cos(4 * angle));
    ctx.lineTo(w / 2 + x, h * 0.45 + y);
  }
  ctx.stroke();
  ctx.fill();

  let image = ctx.getImageData(0, 0, w, h);
  imageBuffer = new Uint32Array(image.data.buffer);
}

setup();
draw();