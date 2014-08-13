
/*
* "Sluggifica" o conteúdo de um elemento
* removendo espaços, caracteres especiais e todo esse jazz que adoramos
*/

//função global
function generateSlug(slug) {
    slug = slug.replace(/^\s+|\s+$/g, '').toLowerCase(); // trim e lower

    // substituindo caracteres acentuados (tem jeito melhor de fazer isso?)
    var from = "àáäãâèéëêìíïîòóöõôùúüûñç·/_,:;";
    var to = "aaaaaeeeeiiiiooooouuuunc------";
    for (var i = 0, l = from.length; i < l; i++) {
        slug = slug.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
    }

    return slug.replace(/[^a-z0-9 -]/g, '') // removendo caracteres zoados
                .replace(/\s+/g, '-') // transformando espaços em -
                .replace(/-+/g, '-'); // removendo - seguidos
}

//plugin do jquery
(function ($) {
    $.fn.generateSlug = function () {

        return this.each(function () {
            var $this = $(this);

            $this.val(generateSlug($this.val()));
        });

    };
})(jQuery);

