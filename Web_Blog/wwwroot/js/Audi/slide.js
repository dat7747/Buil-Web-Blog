let currentIndex = 0;

function formatCurrency(amount) {
    let formattedAmount = amount.toString();
    formattedAmount = formattedAmount.replace(/\B(?=(\d{3})+(?!\d))/g, '.');
    return formattedAmount + ' VNĐ';
}

function showSlide(index) {
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;

    if (totalSlides === 0) return;

    if (index >= totalSlides) {
        currentIndex = 0;
    } else if (index < 0) {
        currentIndex = totalSlides - 1;
    } else {
        currentIndex = index;
    }

    const slideWidth = document.querySelector('.slider-container').clientWidth;
    document.querySelector('.slider').style.transform = `translateX(${-slideWidth * currentIndex}px)`;
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function showCarDetails(imagePath, carName, carPower, carAcceleration, carTorque, carTopSpeed, carPrice) {
    const carImage = document.getElementById('carImage');
    const carNameElement = document.getElementById('carName');
    const carPowerElement = document.getElementById('carPower');
    const carAccelerationElement = document.getElementById('carAcceleration');
    const carTorqueElement = document.getElementById('carTorque');
    const carTopSpeedElement = document.getElementById('carTopSpeed');
    const carPriceElement = document.getElementById('carPrice');

    // Log kiểm tra các phần tử
    console.log({
        carImage,
        carNameElement,
        carPowerElement,
        carAccelerationElement,
        carTorqueElement,
        carTopSpeedElement,
        carPriceElement
    });

    if (carImage && carNameElement && carPowerElement && carAccelerationElement && carTorqueElement && carTopSpeedElement && carPriceElement) {
        carImage.src = imagePath;
        carNameElement.textContent = carName;
        carPowerElement.textContent = carPower + " kW";
        carAccelerationElement.textContent = carAcceleration + " giây";
        carTorqueElement.textContent = carTorque + " Nm";
        carTopSpeedElement.textContent = carTopSpeed + " km/h";
        carPriceElement.textContent = formatCurrency(carPrice);
    } else {
        console.error('One or more car detail elements are missing.');
    }
}

function filterProductsByBrand(brandId) {
    const slides = document.querySelectorAll('.slide');
    slides.forEach(slide => {
        const slideBrandId = slide.getAttribute('data-brand-id');
        if (slideBrandId === brandId) {
            slide.style.display = 'block';
        } else {
            slide.style.display = 'none';
        }
    });
    showSlide(0);
}

window.onload = function() {
    const menuItems = document.querySelectorAll('.menu-item-car');
    menuItems.forEach(menuItem => {
        menuItem.addEventListener('click', function() {
            const brandId = this.getAttribute('data-brand-id');
            filterProductsByBrand(brandId);
        });
    });
    showSlide(currentIndex);
}
