
jQuery(document).ready(function () {

	//make textarea edits go back into the dom (they were designed to be POST'ed via forms)
	jQuery("textarea").blur(function () { this.innerHTML = this.value; });



	//when a textarea gets focus, send Bloom a dictionary of all the translations found within
	//the same parent element
	jQuery("textarea").focus(function () {
		event = document.createEvent('MessageEvent');
		var origin = window.location.protocol + '//' + window.location.host;
		var obj = {};
		$(this).parent().find("textarea").each(function () {
			obj[$(this).attr("lang")] = $(this).text();
		})
		var json = obj; //.get();
		json = JSON.stringify(json);
		event.initMessageEvent('textGroupFocussed', true, true, json, origin, 1234, window, null);
		document.dispatchEvent(event);
	});


	//when a textarea is overfull, add the overflow class so that it gets a red background or something
	//NB: we would like to run this even when there is a mouse paste, but currently don't know how
	//to get that event. You'd think change() would do it, but it doesn't. http://stackoverflow.com/questions/3035633/jquery-change-not-working-incase-of-dynamic-value-change
	jQuery("textarea").keypress(function () {
		var overflowing = this.scrollHeight > this.clientHeight;
		if ($(this).hasClass('overflow') && !overflowing) {
			$(this).removeClass('overflow');
		}
		else if (overflowing) {
			$(this).addClass('overflow');
		}
	});

	//put hint bubbles next to elements which call for them
	$("*[data-hint]").each(function () {
		if($(this).css('border-bottom-color') == 'transparent')
		{
			return; //don't put tips if they can't edit it. That's just confusing
		}
		if($(this).css('display') == 'none')
		{
			return; //don't put tips if they can't see it.
		}
		theClasses='ui-tooltip-shadow ui-tooltip-plain';
		pos =  {        at: 'right center',
						my: 'left center'
			   };

		var whatToSay = $(this).data("hint");
		$(this).qtip({
			content: whatToSay,
			position: pos,
			show: {
				event: false, // Don't specify a show event...
				ready: true // ... but show the tooltip when ready
			},
			hide: false,
			style: {
				classes: theClasses
			},
			//the following is to limit how much stuff qtip leaves in our DOM
			//since we actually save the dom, we dont' want this stuff
			//1) we're using data-hint instead of title. That makes it easy
			//to clean up (with title, qtip moves it to oldtitle, and if we
			//move it back below, well now we also get standard browser tooltips.
			//2) we prerender
			//3) after the render, we clean up this aria-describedby attr
			//4) somebody needs to call the qtipCleanupFunction to remove the div
			prerender: true,
			events: {
				render: function (event, api) {
					$('*[oldtitle]').each(function () {
						$(this)[0].removeAttribute('aria-describedby');
					});
				}
			}
		});
	});

	$.fn.hasAttr = function(name) {
		var attr = $(this).attr(name);

		// For some browsers, `attr` is undefined; for others,
		// `attr` is false.  Check for both.
		return (typeof attr !== 'undefined' && attr !== false);
	};

	//Show data on fields
		   $("*[data-book], *[data-library], *[lang]").each(function () {
			   var data=" ";
			  if($(this).hasAttr("data-book")) {
				  data = $(this).attr("data-book");
			  }
			  if($(this).hasAttr("data-library")) {
				  data = $(this).attr("data-library") ;
			  }
			  $(this).qtipSecondary({
				  content: { text:  $(this).attr("lang") + "<br>"+ data},//, title: { text:  $(this).attr("lang")}},

				  position:  {
					  my: 'top right',
					  at: 'top left'
				  },
//                  show: {
//                                  event: false, // Don't specify a show event...
//                                  ready: true // ... but show the tooltip when ready
//                              },
//                  hide:false,//{     fixed: true },// Make it fixed so it can be hovered over    },
				  style: {'default': false,
					  tip: {corner: false, border:false},
					  classes: 'fieldInfo-qtip'
				  }
			  });
		  });

	cleanup = function(){
		// remove the div's which qtip makes for the tips themselves
		$("div.qtip").each(function() {
		 */
			$(this).remove($this);
		})
		// remove the attributes qtips adds to the things being annotated
		$("*[aria-describedby").each(function() {
			$(this).removeAttr("aria-describedby");
		})
//        $("*").each(function() {
//            $(this).removeAttr("aria-live");
//            $(this).removeAttr("aria-atomic");
//            $(this).removeAttr("aria-describedby");
//            $(this).removeAttr("aria-hidden");
//        })
	}

	//make images look click-able when you cover over them
	jQuery("img").hover(function () {
		$(this).addClass('hoverUp')
	}, function () {
		$(this).removeClass('hoverUp')
	});

	//focus on the first editable field
	$(':input:enabled:visible:first').focus();

	// Bloom needs to make some field readonly. E.g., the original license when the user is translating a shellbook
	// Normally, we'd control this is a style in editTranslationMode.css. However, "readonly" isn't a style, just
	// an attribute, so it can't be included in css.
	// The solution here is to add the readonly attribute when we detect that their border has gone transparent.
	$('textarea').focus(function() {
		if($(this).css('border-bottom-color') == 'transparent'){
					$(this).attr("readonly", "readonly");
				}
				else{
					$(this).removeAttr("readonly");
				}
	});

	//Same thing for divs which are potentially editable.
	// editTranslationMode.css is responsible for making this transparent, but it can't reach the contentEditable attribute.
	$('div.readOnlyInTranslationMode').focus(function() {
		if($(this).css('border-bottom-color') == 'transparent'){
					$(this).removeAttr("contentEditable");
				}
		else{
			$(this).attr("contentEditable", "true");
		}
	});

});