function switchTheme(isDark) {
    if (isDark) {
        document.documentElement.style.setProperty('--background-color', '#313131');
    } else {
        document.documentElement.style.setProperty('--background-color', '#f6f6f6');
    }
}