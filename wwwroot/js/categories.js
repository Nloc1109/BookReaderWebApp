// CATEGORIES PAGE JAVASCRIPT

document.addEventListener('DOMContentLoaded', function() {
    initSearch();
    initViewOptions();
    initFilterOptions();
    initCategoryCards();
    initCategoryItems();
    initScrollEffects();
    initScrollAnimations();
    initLazyLoading();
    initSmoothScrolling();
    initKeyboardShortcuts();
});

// Search functionality
function initSearch() {
    const searchInput = document.querySelector('.hero-search-input');
    const searchBtn = document.querySelector('.search-btn');
    
    if (!searchInput || !searchBtn) return;
    
    // Auto focus search input
    searchInput.focus();
    
    // Search on button click
    searchBtn.addEventListener('click', function() {
        performSearch();
    });
    
    // Search on Enter key
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            performSearch();
        }
    });
    
    // Real-time search with debounce
    let searchTimeout;
    searchInput.addEventListener('input', function() {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(() => {
            performRealTimeSearch();
        }, 300);
    });
}

function performSearch() {
    const searchInput = document.querySelector('.hero-search-input');
    const query = searchInput.value.trim();
    
    if (query) {
        // Add loading state
        const searchBtn = document.querySelector('.search-btn');
        const originalText = searchBtn.innerHTML;
        searchBtn.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
        searchBtn.disabled = true;
        
        // Simulate search delay
        setTimeout(() => {
            // Redirect to search results page
            window.location.href = `/Books/Search?q=${encodeURIComponent(query)}`;
        }, 500);
    }
}

function performRealTimeSearch() {
    const searchInput = document.querySelector('.hero-search-input');
    const query = searchInput.value.trim().toLowerCase();
    
    if (query.length < 2) {
        // Show all categories if query is too short
        showAllCategories();
        return;
    }
    
    // Filter categories in real-time
    const categoryCards = document.querySelectorAll('.category-card-large');
    const categoryItems = document.querySelectorAll('.category-item');
    
    let hasResults = false;
    
    // Filter large category cards
    categoryCards.forEach(card => {
        const title = card.querySelector('h3').textContent.toLowerCase();
        const description = card.querySelector('p').textContent.toLowerCase();
        
        if (title.includes(query) || description.includes(query)) {
            card.style.display = 'block';
            hasResults = true;
        } else {
            card.style.display = 'none';
        }
    });
    
    // Filter category items
    categoryItems.forEach(item => {
        const title = item.querySelector('h3').textContent.toLowerCase();
        const description = item.querySelector('p').textContent.toLowerCase();
        
        if (title.includes(query) || description.includes(query)) {
            item.style.display = 'flex';
            hasResults = true;
        } else {
            item.style.display = 'none';
        }
    });
    
    // Show/hide no results message
    showNoResultsMessage(!hasResults);
}

function showAllCategories() {
    const categoryCards = document.querySelectorAll('.category-card-large');
    const categoryItems = document.querySelectorAll('.category-item');
    
    categoryCards.forEach(card => {
        card.style.display = 'block';
    });
    
    categoryItems.forEach(item => {
        item.style.display = 'flex';
    });
    
    showNoResultsMessage(false);
}

function showNoResultsMessage(show) {
    let noResultsMsg = document.querySelector('.no-results-message');
    
    if (show) {
        if (!noResultsMsg) {
            noResultsMsg = document.createElement('div');
            noResultsMsg.className = 'no-results-message';
            noResultsMsg.innerHTML = `
                <div style="text-align: center; padding: 3rem; color: rgba(255,255,255,0.7);">
                    <i class="fas fa-search" style="font-size: 3rem; margin-bottom: 1rem; opacity: 0.5;"></i>
                    <h3>Không tìm thấy thể loại</h3>
                    <p>Thử tìm kiếm với từ khóa khác hoặc duyệt tất cả thể loại</p>
                </div>
            `;
            document.querySelector('.categories-grid').appendChild(noResultsMsg);
        }
        noResultsMsg.style.display = 'block';
    } else if (noResultsMsg) {
        noResultsMsg.style.display = 'none';
    }
}

// View options (grid/list)
function initViewOptions() {
    const viewBtns = document.querySelectorAll('.view-btn');
    const categoriesGrid = document.querySelector('.categories-grid');
    
    viewBtns.forEach(btn => {
        btn.addEventListener('click', function() {
            const viewType = this.dataset.view;
            
            // Update active button
            viewBtns.forEach(b => b.classList.remove('active'));
            this.classList.add('active');
            
            // Update grid layout
            if (viewType === 'list') {
                categoriesGrid.style.gridTemplateColumns = '1fr';
                categoriesGrid.style.gap = '1rem';
            } else {
                categoriesGrid.style.gridTemplateColumns = 'repeat(auto-fit, minmax(350px, 1fr))';
                categoriesGrid.style.gap = '2rem';
            }
        });
    });
}

// Filter options
function initFilterOptions() {
    const filterSelect = document.querySelector('.filter-select');
    
    if (!filterSelect) return;
    
    filterSelect.addEventListener('change', function() {
        const filterValue = this.value;
        applyFilter(filterValue);
    });
}

function applyFilter(filterType) {
    const categoryCards = document.querySelectorAll('.category-card-large');
    const categoryItems = document.querySelectorAll('.category-item');
    
    // Convert to arrays for sorting
    const cardsArray = Array.from(categoryCards);
    const itemsArray = Array.from(categoryItems);
    
    // Sort based on filter type
    switch (filterType) {
        case 'popular':
            sortByPopularity(cardsArray, itemsArray);
            break;
        case 'newest':
            sortByNewest(cardsArray, itemsArray);
            break;
        case 'most-books':
            sortByBookCount(cardsArray, itemsArray);
            break;
        default:
            // Reset to original order
            resetOrder(cardsArray, itemsArray);
    }
}

function sortByPopularity(cardsArray, itemsArray) {
    // Sort by reader count (simplified)
    cardsArray.sort((a, b) => {
        const aCount = parseInt(a.querySelector('.reader-count').textContent.replace(/[^\d]/g, ''));
        const bCount = parseInt(b.querySelector('.reader-count').textContent.replace(/[^\d]/g, ''));
        return bCount - aCount;
    });
    
    itemsArray.sort((a, b) => {
        const aCount = parseInt(a.querySelector('.reader-count').textContent.replace(/[^\d]/g, ''));
        const bCount = parseInt(b.querySelector('.reader-count').textContent.replace(/[^\d]/g, ''));
        return bCount - aCount;
    });
    
    reorderElements(cardsArray, itemsArray);
}

function sortByBookCount(cardsArray, itemsArray) {
    // Sort by book count
    cardsArray.sort((a, b) => {
        const aCount = parseInt(a.querySelector('.book-count').textContent.replace(/[^\d]/g, ''));
        const bCount = parseInt(b.querySelector('.book-count').textContent.replace(/[^\d]/g, ''));
        return bCount - aCount;
    });
    
    itemsArray.sort((a, b) => {
        const aCount = parseInt(a.querySelector('.book-count').textContent.replace(/[^\d]/g, ''));
        const bCount = parseInt(b.querySelector('.book-count').textContent.replace(/[^\d]/g, ''));
        return bCount - aCount;
    });
    
    reorderElements(cardsArray, itemsArray);
}

function sortByNewest(cardsArray, itemsArray) {
    // For demo purposes, just shuffle the order
    cardsArray.sort(() => Math.random() - 0.5);
    itemsArray.sort(() => Math.random() - 0.5);
    
    reorderElements(cardsArray, itemsArray);
}

function resetOrder(cardsArray, itemsArray) {
    // Reset to original order (you might want to store original order)
    reorderElements(cardsArray, itemsArray);
}

function reorderElements(cardsArray, itemsArray) {
    const categoriesGrid = document.querySelector('.categories-grid');
    const categoriesList = document.querySelector('.categories-list');
    
    // Reorder cards
    cardsArray.forEach(card => {
        categoriesGrid.appendChild(card);
    });
    
    // Reorder items
    itemsArray.forEach(item => {
        categoriesList.appendChild(item);
    });
    
    // Add animation
    addReorderAnimation();
}

function addReorderAnimation() {
    const elements = document.querySelectorAll('.category-card-large, .category-item');
    
    elements.forEach((el, index) => {
        el.style.animation = 'none';
        el.offsetHeight; // Trigger reflow
        el.style.animation = `slideInUp 0.5s ease forwards ${index * 0.1}s`;
    });
}

// Category card interactions
function initCategoryCards() {
    const categoryCards = document.querySelectorAll('.category-card-large');
    
    categoryCards.forEach(card => {
        // Click to explore
        card.addEventListener('click', function() {
            const categoryName = this.querySelector('h3').textContent;
            exploreCategory(categoryName);
        });
        
        // Hover effects
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-5px) scale(1.02)';
        });
        
        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0) scale(1)';
        });
    });
}

function exploreCategory(categoryName) {
    // Add loading animation
    const card = event.currentTarget;
    const overlay = card.querySelector('.category-overlay');
    const btn = overlay.querySelector('.btn-explore');
    
    btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Khám phá...';
    
    // Simulate loading
    setTimeout(() => {
        // Redirect to category detail page
        const encodedName = encodeURIComponent(categoryName);
        window.location.href = `/Categories/Detail/${encodedName}`;
    }, 500);
}

// Category item interactions
function initCategoryItems() {
    const categoryItems = document.querySelectorAll('.category-item');
    
    categoryItems.forEach(item => {
        const viewBtn = item.querySelector('.btn-view');
        
        viewBtn.addEventListener('click', function(e) {
            e.stopPropagation();
            const categoryName = item.querySelector('h3').textContent;
            viewCategory(categoryName);
        });
        
        // Click on item to view
        item.addEventListener('click', function() {
            const categoryName = this.querySelector('h3').textContent;
            viewCategory(categoryName);
        });
    });
}

function viewCategory(categoryName) {
    // Add loading state
    const btn = event.target;
    const originalText = btn.textContent;
    btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i>';
    btn.disabled = true;
    
    // Simulate loading
    setTimeout(() => {
        // Redirect to category detail page
        const encodedName = encodeURIComponent(categoryName);
        window.location.href = `/Categories/Detail/${encodedName}`;
    }, 300);
}

// Scroll effects
function initScrollEffects() {
    // Smooth scrolling for horizontal containers
    const scrollContainers = document.querySelectorAll('.categories-grid, .categories-list');
    
    scrollContainers.forEach(container => {
        let isScrolling = false;
        let startX, scrollLeft;
        
        container.addEventListener('mousedown', function(e) {
            isScrolling = true;
            startX = e.pageX - container.offsetLeft;
            scrollLeft = container.scrollLeft;
            container.style.cursor = 'grabbing';
        });
        
        container.addEventListener('mouseleave', function() {
            isScrolling = false;
            container.style.cursor = 'grab';
        });
        
        container.addEventListener('mouseup', function() {
            isScrolling = false;
            container.style.cursor = 'grab';
        });
        
        container.addEventListener('mousemove', function(e) {
            if (!isScrolling) return;
            e.preventDefault();
            const x = e.pageX - container.offsetLeft;
            const walk = (x - startX) * 2;
            container.scrollLeft = scrollLeft - walk;
        });
    });
}

// Scroll animations
function initScrollAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };
    
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.animation = 'fadeInUp 0.6s ease forwards';
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);
    
    // Observe sections
    const sections = document.querySelectorAll('.popular-categories-section, .all-categories-section');
    sections.forEach(section => {
        observer.observe(section);
    });
    
    // Observe category cards
    const cards = document.querySelectorAll('.category-card-large, .category-item');
    cards.forEach((card, index) => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(30px)';
        observer.observe(card);
    });
}

// Lazy loading for images
function initLazyLoading() {
    const imageObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                img.src = img.dataset.src;
                img.classList.remove('lazy');
                imageObserver.unobserve(img);
            }
        });
    });
    
    const lazyImages = document.querySelectorAll('img[data-src]');
    lazyImages.forEach(img => imageObserver.observe(img));
}

// Smooth scrolling for anchor links
function initSmoothScrolling() {
    const anchorLinks = document.querySelectorAll('a[href^="#"]');
    
    anchorLinks.forEach(link => {
        link.addEventListener('click', function(e) {
            e.preventDefault();
            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);
            
            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });
}

// Keyboard shortcuts
function initKeyboardShortcuts() {
    document.addEventListener('keydown', function(e) {
        // Ctrl/Cmd + K to focus search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('.hero-search-input');
            if (searchInput) {
                searchInput.focus();
                searchInput.select();
            }
        }
        
        // Escape to clear search
        if (e.key === 'Escape') {
            const searchInput = document.querySelector('.hero-search-input');
            if (searchInput && document.activeElement === searchInput) {
                searchInput.value = '';
                searchInput.blur();
                showAllCategories();
            }
        }
        
        // Arrow keys for navigation (if needed)
        if (e.key === 'ArrowRight' || e.key === 'ArrowLeft') {
            // Could implement category navigation here
        }
    });
}

// Add CSS animations
const style = document.createElement('style');
style.textContent = `
    @keyframes fadeInUp {
        from {
            opacity: 0;
            transform: translateY(30px);
        }
        to {
            opacity: 1;
            transform: translateY(0);
        }
    }
    
    @keyframes slideInUp {
        from {
            opacity: 0;
            transform: translateY(20px);
        }
        to {
            opacity: 1;
            transform: translateY(0);
        }
    }
    
    .category-card-large,
    .category-item {
        transition: all 0.3s ease;
    }
    
    .category-card-large:hover,
    .category-item:hover {
        transform: translateY(-5px);
        box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
    }
    
    .btn-explore,
    .btn-view {
        transition: all 0.3s ease;
    }
    
    .btn-explore:hover,
    .btn-view:hover {
        transform: scale(1.05);
    }
    
    .search-container {
        transition: all 0.3s ease;
    }
    
    .search-container:focus-within {
        transform: scale(1.02);
        box-shadow: 0 0 20px rgba(78, 222, 128, 0.3);
    }
    
    .stat-item {
        transition: all 0.3s ease;
    }
    
    .stat-item:hover {
        transform: translateY(-2px) scale(1.05);
    }
    
    .preview-item {
        transition: all 0.3s ease;
    }
    
    .preview-item:hover {
        transform: translateX(5px) scale(1.05);
    }
    
    .floating-book {
        transition: all 0.3s ease;
    }
    
    .floating-book:hover {
        transform: scale(1.2) rotate(10deg);
    }
`;
document.head.appendChild(style); 