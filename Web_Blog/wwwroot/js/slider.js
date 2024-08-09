let slides = document.querySelectorAll('.slide');
let currentIndex = 0;
const slideDuration = 3000;

function showSlide(index) {
    currentIndex = (index + slides.length) % slides.length;
    document.querySelector('.slider').style.transform = `translateX(-${currentIndex * 100}%)`;
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

setInterval(nextSlide, slideDuration);
