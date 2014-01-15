function OnBegin(attributes, arguments) {
    history.pushState(null, null, arguments.url.replace("?X-Requested-With=XMLHttpRequest", ''));
}
