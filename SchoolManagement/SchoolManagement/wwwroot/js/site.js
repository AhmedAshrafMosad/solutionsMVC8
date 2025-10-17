// School Management System - Enhanced JavaScript

document.addEventListener('DOMContentLoaded', function () {
    // Enable tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Enable popovers
    var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'));
    var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
        return new bootstrap.Popover(popoverTriggerEl);
    });

    // Auto-dismiss alerts after 5 seconds
    setTimeout(function () {
        var alerts = document.querySelectorAll('.alert:not(.alert-permanent)');
        alerts.forEach(function (alert) {
            var bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        });
    }, 5000);

    // Enhanced form validation
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        // Add loading state to submit buttons
        form.addEventListener('submit', function (e) {
            const submitBtn = this.querySelector('button[type="submit"]');
            if (submitBtn && !this.classList.contains('no-loading')) {
                submitBtn.disabled = true;
                const originalText = submitBtn.innerHTML;
                submitBtn.innerHTML = '<span class="loading me-2"></span> Processing...';

                // Revert after 10 seconds (safety net)
                setTimeout(() => {
                    submitBtn.disabled = false;
                    submitBtn.innerHTML = originalText;
                }, 10000);
            }
        });

        // Real-time validation
        const inputs = form.querySelectorAll('input, select, textarea');
        inputs.forEach(input => {
            input.addEventListener('blur', function () {
                validateField(this);
            });

            input.addEventListener('input', function () {
                if (this.classList.contains('is-invalid')) {
                    validateField(this);
                }
            });
        });

        function validateField(field) {
            if (field.checkValidity()) {
                field.classList.remove('is-invalid');
                field.classList.add('is-valid');
            } else {
                field.classList.remove('is-valid');
                field.classList.add('is-invalid');
            }
        }
    });

    // Table row selection and actions
    const tableRows = document.querySelectorAll('table tbody tr[data-id]');
    tableRows.forEach(row => {
        row.addEventListener('click', function (e) {
            if (e.target.tagName === 'A' || e.target.tagName === 'BUTTON') {
                return;
            }
            const id = this.getAttribute('data-id');
            window.location.href = `${window.location.pathname}/${id}`;
        });

        row.style.cursor = 'pointer';
    });

    // Search functionality enhancement
    const searchForms = document.querySelectorAll('form[method="get"]');
    searchForms.forEach(form => {
        const searchInput = form.querySelector('input[name="searchName"]');
        if (searchInput) {
            let searchTimeout;
            searchInput.addEventListener('input', function () {
                clearTimeout(searchTimeout);
                searchTimeout = setTimeout(() => {
                    if (this.value.length >= 2 || this.value.length === 0) {
                        form.submit();
                    }
                }, 500);
            });
        }
    });

    // Department filter change
    const departmentFilter = document.querySelector('select[name="departmentId"], select[name="FilterDepartmentId"]');
    if (departmentFilter) {
        departmentFilter.addEventListener('change', function () {
            this.form.submit();
        });
    }

    // Confirmation for delete actions
    const deleteForms = document.querySelectorAll('form[action*="Delete"]');
    deleteForms.forEach(form => {
        form.addEventListener('submit', function (e) {
            if (!confirm('Are you sure you want to delete this item? This action cannot be undone.')) {
                e.preventDefault();
            }
        });
    });

    // Pagination enhancement
    const paginationLinks = document.querySelectorAll('.pagination a');
    paginationLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            window.location.href = this.href;
        });
    });

    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
            }
        });
    });

    // Dynamic page title based on route
    function updatePageTitle() {
        const path = window.location.pathname;
        const titles = {
            '/students': 'Students - School Management',
            '/departments': 'Departments - School Management',
            '/courses': 'Courses - School Management',
            '/results': 'Course Results - School Management'
        };

        for (const [route, title] of Object.entries(titles)) {
            if (path.startsWith(route)) {
                document.title = title;
                break;
            }
        }
    }

    updatePageTitle();

    // Active navigation highlighting
    function setActiveNavItem() {
        const currentPath = window.location.pathname;
        const navLinks = document.querySelectorAll('.navbar-nav .nav-link');

        navLinks.forEach(link => {
            link.classList.remove('active');
            const linkPath = link.getAttribute('href');

            if (currentPath === linkPath ||
                (linkPath !== '/' && currentPath.startsWith(linkPath))) {
                link.classList.add('active');
            }
        });
    }

    setActiveNavItem();
});

// Global functions
function showLoading(button) {
    if (button) {
        const originalText = button.innerHTML;
        button.disabled = true;
        button.innerHTML = '<span class="loading me-2"></span> Loading...';
        return originalText;
    }
}

function hideLoading(button, originalText) {
    if (button && originalText) {
        button.disabled = false;
        button.innerHTML = originalText;
    }
}

function showToast(message, type = 'info') {
    // Simple toast implementation - you can replace with a proper toast library
    const toast = document.createElement('div');
    toast.className = `alert alert-${type} alert-dismissible fade show position-fixed`;
    toast.style.cssText = 'top: 20px; right: 20px; z-index: 9999; min-width: 300px;';
    toast.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    document.body.appendChild(toast);

    setTimeout(() => {
        toast.remove();
    }, 5000);
}