// CATEGORY DETAIL PAGE JAVASCRIPT

document.addEventListener('DOMContentLoaded', function() {
    initSearch();
    initFilters();
    initViewOptions();
    initBookCards();
    initPagination();
    initScrollAnimations();
    initLazyLoading();
    initKeyboardShortcuts();
    updateBooksCount();
});

// Search functionality
function initSearch() {
    const searchInput = document.querySelector('.search-input');
    
    if (!searchInput) return;
    
    // Auto focus search input
    searchInput.focus();
    
    // Real-time search with debounce
    let searchTimeout;
    searchInput.addEventListener('input', function() {
        clearTimeout(searchTimeout);
        searchTimeout = setTimeout(() => {
            performSearch();
        }, 300);
    });
    
    // Search on Enter key
    searchInput.addEventListener('keypress', function(e) {
        if (e.key === 'Enter') {
            performSearch();
        }
    });
}

function performSearch() {
    const searchInput = document.querySelector('.search-input');
    const query = searchInput.value.trim().toLowerCase();
    const bookCards = document.querySelectorAll('.book-card');
    
    let visibleCount = 0;
    
    bookCards.forEach(card => {
        const title = card.querySelector('h3').textContent.toLowerCase();
        const author = card.querySelector('.book-author').textContent.toLowerCase();
        
        if (title.includes(query) || author.includes(query)) {
            card.style.display = 'block';
            visibleCount++;
        } else {
            card.style.display = 'none';
        }
    });
    
    updateBooksCount(visibleCount);
    showNoResultsMessage(visibleCount === 0 && query.length > 0);
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
                    <h3>Không tìm thấy sách</h3>
                    <p>Thử tìm kiếm với từ khóa khác hoặc thay đổi bộ lọc</p>
                </div>
            `;
            document.querySelector('.books-grid').appendChild(noResultsMsg);
        }
        noResultsMsg.style.display = 'block';
    } else if (noResultsMsg) {
        noResultsMsg.style.display = 'none';
    }
}

// Filter functionality
function initFilters() {
    const sortFilter = document.getElementById('sort-filter');
    const formatFilter = document.getElementById('format-filter');
    const languageFilter = document.getElementById('language-filter');
    
    [sortFilter, formatFilter, languageFilter].forEach(filter => {
        if (filter) {
            filter.addEventListener('change', function() {
                applyFilters();
            });
        }
    });
}

function applyFilters() {
    const sortValue = document.getElementById('sort-filter')?.value;
    const formatValue = document.getElementById('format-filter')?.value;
    const languageValue = document.getElementById('language-filter')?.value;
    
    const bookCards = Array.from(document.querySelectorAll('.book-card'));
    
    // Apply format filter
    if (formatValue) {
        bookCards.forEach(card => {
            const format = card.querySelector('.book-format').textContent.toLowerCase();
            const isVisible = format.includes(formatValue);
            card.style.display = isVisible ? 'block' : 'none';
        });
    }
    
    // Apply sorting
    if (sortValue) {
        const visibleCards = bookCards.filter(card => card.style.display !== 'none');
        
        switch (sortValue) {
            case 'popular':
                sortByPopularity(visibleCards);
                break;
            case 'newest':
                sortByNewest(visibleCards);
                break;
            case 'rating':
                sortByRating(visibleCards);
                break;
            case 'title':
                sortByTitle(visibleCards);
                break;
        }
    }
    
    updateBooksCount();
}

function sortByPopularity(cards) {
    cards.sort((a, b) => {
        const aRating = parseInt(a.querySelector('.rating-text').textContent.match(/\d+/)[0]);
        const bRating = parseInt(b.querySelector('.rating-text').textContent.match(/\d+/)[0]);
        return bRating - aRating;
    });
    reorderCards(cards);
}

function sortByRating(cards) {
    cards.sort((a, b) => {
        const aRating = parseFloat(a.querySelector('.rating-text').textContent.split(' ')[0]);
        const bRating = parseFloat(b.querySelector('.rating-text').textContent.split(' ')[0]);
        return bRating - aRating;
    });
    reorderCards(cards);
}

function sortByTitle(cards) {
    cards.sort((a, b) => {
        const aTitle = a.querySelector('h3').textContent.toLowerCase();
        const bTitle = b.querySelector('h3').textContent.toLowerCase();
        return aTitle.localeCompare(bTitle);
    });
    reorderCards(cards);
}

function sortByNewest(cards) {
    // For demo purposes, just shuffle the order
    cards.sort(() => Math.random() - 0.5);
    reorderCards(cards);
}

function reorderCards(cards) {
    const container = document.querySelector('.books-grid');
    cards.forEach(card => {
        container.appendChild(card);
    });
    
    // Add animation
    addReorderAnimation();
}

function addReorderAnimation() {
    const cards = document.querySelectorAll('.book-card');
    cards.forEach((card, index) => {
        card.style.animation = 'none';
        card.offsetHeight; // Trigger reflow
        card.style.animation = `slideInUp 0.5s ease forwards ${index * 0.1}s`;
    });
}

// View options
function initViewOptions() {
    const viewBtns = document.querySelectorAll('.view-btn');
    const booksGrid = document.querySelector('.books-grid');
    
    viewBtns.forEach(btn => {
        btn.addEventListener('click', function() {
            const viewType = this.dataset.view;
            
            // Update active button
            viewBtns.forEach(b => b.classList.remove('active'));
            this.classList.add('active');
            
            // Update grid layout
            if (viewType === 'list') {
                booksGrid.style.gridTemplateColumns = '1fr';
                booksGrid.style.gap = '1rem';
                booksGrid.classList.add('list-view');
            } else {
                booksGrid.style.gridTemplateColumns = 'repeat(auto-fill, minmax(250px, 1fr))';
                booksGrid.style.gap = '2rem';
                booksGrid.classList.remove('list-view');
            }
        });
    });
}

// Book card interactions
function initBookCards() {
    const bookCards = document.querySelectorAll('.book-card');
    
    bookCards.forEach(card => {
        // Read button
        const readBtn = card.querySelector('.btn-read');
        if (readBtn) {
            readBtn.addEventListener('click', function(e) {
                e.stopPropagation();
                const bookTitle = card.querySelector('h3').textContent;
                startReading(bookTitle);
            });
        }
        
        // Preview button
        const previewBtn = card.querySelector('.btn-preview');
        if (previewBtn) {
            previewBtn.addEventListener('click', function(e) {
                e.stopPropagation();
                const bookTitle = card.querySelector('h3').textContent;
                previewBook(bookTitle);
            });
        }
        
        // Click on card
        card.addEventListener('click', function() {
            const bookTitle = this.querySelector('h3').textContent;
            showBookDetails(bookTitle);
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

function startReading(bookTitle) {
    // Add loading state
    const btn = event.target;
    const originalText = btn.textContent;
    btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang tải...';
    btn.disabled = true;
    
    // Simulate loading
    setTimeout(() => {
        // Redirect to reading page
        window.location.href = `/Reader/Read?book=${encodeURIComponent(bookTitle)}`;
    }, 1000);
}

function previewBook(bookTitle) {
    // Add loading state
    const btn = event.target;
    const originalText = btn.textContent;
    btn.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Đang tải...';
    btn.disabled = true;
    
    // Simulate loading
    setTimeout(() => {
        // Show preview modal or redirect
        showPreviewModal(bookTitle);
        btn.innerHTML = originalText;
        btn.disabled = false;
    }, 800);
}

function showBookDetails(bookTitle) {
    // Add loading animation
    const card = event.currentTarget;
    card.style.transform = 'scale(0.95)';
    
    setTimeout(() => {
        // Redirect to book details page
        window.location.href = `/Books/Details?title=${encodeURIComponent(bookTitle)}`;
    }, 200);
}

function showPreviewModal(bookTitle) {
    // Create modal
    const modal = document.createElement('div');
    modal.className = 'preview-modal';
    modal.innerHTML = `
        <div class="modal-overlay">
            <div class="modal-content">
                <div class="modal-header">
                    <h3>Xem trước: ${bookTitle}</h3>
                    <button class="modal-close">
                        <i class="fas fa-times"></i>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="preview-content">
                        <p>Đây là nội dung xem trước của cuốn sách "${bookTitle}". Bạn có thể đọc một phần đầu để quyết định có muốn đọc tiếp hay không.</p>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                        <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                    </div>
                </div>
                <div class="modal-footer">
                    <button class="btn-secondary" onclick="closePreviewModal()">Đóng</button>
                    <button class="btn-primary" onclick="startReading('${bookTitle}')">Đọc ngay</button>
                </div>
            </div>
        </div>
    `;
    
    document.body.appendChild(modal);
    
    // Close modal functionality
    const closeBtn = modal.querySelector('.modal-close');
    const overlay = modal.querySelector('.modal-overlay');
    
    closeBtn.addEventListener('click', closePreviewModal);
    overlay.addEventListener('click', function(e) {
        if (e.target === overlay) {
            closePreviewModal();
        }
    });
    
    // Add modal styles
    addModalStyles();
}

function closePreviewModal() {
    const modal = document.querySelector('.preview-modal');
    if (modal) {
        modal.remove();
    }
}

function addModalStyles() {
    if (!document.querySelector('#modal-styles')) {
        const style = document.createElement('style');
        style.id = 'modal-styles';
        style.textContent = `
            .preview-modal {
                position: fixed;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                z-index: 1000;
            }
            
            .modal-overlay {
                position: absolute;
                top: 0;
                left: 0;
                right: 0;
                bottom: 0;
                background: rgba(0, 0, 0, 0.8);
                display: flex;
                align-items: center;
                justify-content: center;
                padding: 2rem;
            }
            
            .modal-content {
                background: rgba(255, 255, 255, 0.1);
                backdrop-filter: blur(20px);
                border-radius: 16px;
                border: 1px solid rgba(255, 255, 255, 0.2);
                max-width: 600px;
                width: 100%;
                max-height: 80vh;
                overflow: hidden;
                color: white;
            }
            
            .modal-header {
                display: flex;
                justify-content: space-between;
                align-items: center;
                padding: 1.5rem;
                border-bottom: 1px solid rgba(255, 255, 255, 0.1);
            }
            
            .modal-header h3 {
                margin: 0;
                font-size: 1.3rem;
            }
            
            .modal-close {
                background: none;
                border: none;
                color: white;
                font-size: 1.2rem;
                cursor: pointer;
                padding: 0.5rem;
                border-radius: 50%;
                transition: background 0.3s ease;
            }
            
            .modal-close:hover {
                background: rgba(255, 255, 255, 0.1);
            }
            
            .modal-body {
                padding: 1.5rem;
                max-height: 400px;
                overflow-y: auto;
            }
            
            .preview-content p {
                margin-bottom: 1rem;
                line-height: 1.6;
                opacity: 0.9;
            }
            
            .modal-footer {
                display: flex;
                gap: 1rem;
                padding: 1.5rem;
                border-top: 1px solid rgba(255, 255, 255, 0.1);
                justify-content: flex-end;
            }
            
            .btn-secondary,
            .btn-primary {
                padding: 0.75rem 1.5rem;
                border-radius: 8px;
                border: none;
                cursor: pointer;
                font-weight: 500;
                transition: all 0.3s ease;
            }
            
            .btn-secondary {
                background: rgba(255, 255, 255, 0.1);
                color: white;
                border: 1px solid rgba(255, 255, 255, 0.2);
            }
            
            .btn-primary {
                background: var(--primary-green);
                color: white;
            }
            
            .btn-secondary:hover {
                background: rgba(255, 255, 255, 0.2);
            }
            
            .btn-primary:hover {
                background: #22c55e;
                transform: scale(1.05);
            }
        `;
        document.head.appendChild(style);
    }
}

// Pagination
function initPagination() {
    const paginationBtns = document.querySelectorAll('.pagination-btn');
    
    paginationBtns.forEach(btn => {
        if (!btn.disabled) {
            btn.addEventListener('click', function() {
                const page = this.textContent;
                if (page && !isNaN(page)) {
                    goToPage(parseInt(page));
                } else if (this.querySelector('.fa-chevron-left')) {
                    goToPreviousPage();
                } else if (this.querySelector('.fa-chevron-right')) {
                    goToNextPage();
                }
            });
        }
    });
}

function goToPage(page) {
    // Update active button
    const paginationBtns = document.querySelectorAll('.pagination-btn');
    paginationBtns.forEach(btn => btn.classList.remove('active'));
    
    // Find and activate the clicked button
    paginationBtns.forEach(btn => {
        if (btn.textContent.trim() === page.toString()) {
            btn.classList.add('active');
        }
    });
    
    // Simulate page change
    showLoadingState();
    setTimeout(() => {
        hideLoadingState();
        // Here you would typically load new data from the server
    }, 500);
}

function goToPreviousPage() {
    const activeBtn = document.querySelector('.pagination-btn.active');
    const prevBtn = activeBtn.previousElementSibling;
    
    if (prevBtn && !prevBtn.disabled && !prevBtn.querySelector('.fa-chevron-left')) {
        goToPage(parseInt(prevBtn.textContent));
    }
}

function goToNextPage() {
    const activeBtn = document.querySelector('.pagination-btn.active');
    const nextBtn = activeBtn.nextElementSibling;
    
    if (nextBtn && !nextBtn.disabled && !nextBtn.querySelector('.fa-chevron-right')) {
        goToPage(parseInt(nextBtn.textContent));
    }
}

function showLoadingState() {
    const booksGrid = document.querySelector('.books-grid');
    booksGrid.style.opacity = '0.5';
    booksGrid.style.pointerEvents = 'none';
}

function hideLoadingState() {
    const booksGrid = document.querySelector('.books-grid');
    booksGrid.style.opacity = '1';
    booksGrid.style.pointerEvents = 'auto';
}

// Update books count
function updateBooksCount(count) {
    const booksCountElement = document.getElementById('books-count');
    const totalBooksElement = document.getElementById('total-books');
    
    if (booksCountElement) {
        if (count !== undefined) {
            booksCountElement.textContent = count;
        } else {
            const visibleBooks = document.querySelectorAll('.book-card[style*="display: block"], .book-card:not([style*="display: none"])');
            booksCountElement.textContent = visibleBooks.length;
        }
    }
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
    
    // Observe book cards
    const bookCards = document.querySelectorAll('.book-card');
    bookCards.forEach((card, index) => {
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

// Keyboard shortcuts
function initKeyboardShortcuts() {
    document.addEventListener('keydown', function(e) {
        // Ctrl/Cmd + K to focus search
        if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
            e.preventDefault();
            const searchInput = document.querySelector('.search-input');
            if (searchInput) {
                searchInput.focus();
                searchInput.select();
            }
        }
        
        // Escape to clear search or close modal
        if (e.key === 'Escape') {
            const searchInput = document.querySelector('.search-input');
            if (searchInput && document.activeElement === searchInput) {
                searchInput.value = '';
                searchInput.blur();
                performSearch();
            }
            
            const modal = document.querySelector('.preview-modal');
            if (modal) {
                closePreviewModal();
            }
        }
        
        // Arrow keys for navigation
        if (e.key === 'ArrowRight' || e.key === 'ArrowLeft') {
            if (e.key === 'ArrowLeft') {
                goToPreviousPage();
            } else {
                goToNextPage();
            }
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
    
    .book-card {
        transition: all 0.3s ease;
    }
    
    .book-card:hover {
        transform: translateY(-5px);
        box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
    }
    
    .btn-read,
    .btn-preview {
        transition: all 0.3s ease;
    }
    
    .btn-read:hover,
    .btn-preview:hover {
        transform: scale(1.05);
    }
    
    .search-container {
        transition: all 0.3s ease;
    }
    
    .search-container:focus-within {
        transform: scale(1.02);
        box-shadow: 0 0 20px rgba(78, 222, 128, 0.3);
    }
    
    .filter-select {
        transition: all 0.3s ease;
    }
    
    .filter-select:focus {
        border-color: var(--primary-green);
        box-shadow: 0 0 10px rgba(78, 222, 128, 0.2);
    }
    
    .pagination-btn {
        transition: all 0.3s ease;
    }
    
    .pagination-btn:hover:not(:disabled) {
        transform: scale(1.1);
    }
    
    .list-view .book-card {
        display: flex;
        align-items: center;
        gap: 1.5rem;
        padding: 1rem;
    }
    
    .list-view .book-cover {
        flex: 0 0 120px;
    }
    
    .list-view .book-cover img {
        height: 160px;
    }
    
    .list-view .book-info {
        flex: 1;
        padding: 0;
    }
    
    .list-view .book-overlay {
        display: none;
    }
`;
document.head.appendChild(style); 