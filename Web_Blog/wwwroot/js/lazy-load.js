document.addEventListener("DOMContentLoaded", () => {
    const contentSections = document.querySelectorAll('.content-section');

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const section = entry.target;
                console.log(`Loading content for section with ID: ${section.id}`);
                loadContent(section);
                observer.unobserve(section); // Ngừng quan sát sau khi nội dung được tải
            }
        });
    }, {
        threshold: 0.5 // Quan sát khi ít nhất 50% của phần tử xuất hiện trong viewport
    });

    contentSections.forEach(section => {
        observer.observe(section);
    });

    const loadContent = (section) => {
        const url = section.getAttribute('data-url');
        fetch(url)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.text();
            })
            .then(data => {
                section.innerHTML = data;
                section.classList.add('loaded');
                console.log(`Content loaded for section with ID: ${section.id}`);
            })
            .catch(error => {
                section.innerHTML = 'Không thể tải nội dung.';
                console.error('There has been a problem with your fetch operation:', error);
            });
    };
});
