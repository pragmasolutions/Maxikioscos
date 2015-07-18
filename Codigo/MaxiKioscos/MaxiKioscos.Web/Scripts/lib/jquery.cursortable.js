(function ($) {

    var CursorTable = function (tableElement, options) {

        this.options = options || {};
        this.tableElement = $(tableElement);
        this.tableBody = $(tableElement).find('tbody');
        this.currentRow = $(this.options.currentRow).addClass('highlight') || [];
        this._events = [];
        this._subscribeToEvents();
    };

    CursorTable.prototype = {

        constructor: CursorTable,

        _tableUp: function (e) {
            e.preventDefault();
            if (this.currentRow.length === 0) {
                this.currentRow = $('tr:last', this.tableBody)
                    .addClass('highlight');
                return;
            }

            this.currentRow.toggleClass('highlight');
            var $prevRow = this.currentRow.prev('tr');
            if ($prevRow.length > 0) {
                this.currentRow = $prevRow;
            }

            this.currentRow.toggleClass('highlight');
            this._scrollToCurrentRow();
        },

        _tableDown: function (e) {
            e.preventDefault();

            if (this.currentRow.length === 0) {
                this.currentRow = $('tr:first', this.tableBody)
                    .addClass('highlight');
                return;
            }

            this.currentRow.toggleClass('highlight');
            var $nextRow = this.currentRow.next('tr');
            if ($nextRow.length > 0) {
                this.currentRow = $nextRow;
            }

            this.currentRow.toggleClass('highlight');
            this._scrollToCurrentRow();
        },

        _scrollToCurrentRow: function () {
            if (!this._inViewport(this.currentRow)) {
                
                $('html,body').animate({
                    scrollTop: this.currentRow.position().top - ($(window).height() / 2  - this.currentRow.outerHeight(true))
                }, 0);
            }
        },

        _inViewport : function (el) {
            
            //special bonus for those using jQuery
            if (typeof jQuery === "function" && el instanceof jQuery) {
                el = el[0];
            }

            var rect = el.getBoundingClientRect();

            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && /*or $(window).height() */
                rect.right <= (window.innerWidth || document.documentElement.clientWidth) /*or $(window).width() */
            );
        },


        _tableRowClick: function (e) {
            e.preventDefault();

            var clickedRow = e.currentTarget;
            this.currentRow.removeClass('highlight');
            this.currentRow = $(clickedRow).addClass('highlight');
        },

        _executeAction: function (handler) {
            var event = { currentRow: this.currentRow };
            handler(event);
        },

        _subscribeToEvents: function () {

            this._events.push({ element: document, eventName: 'keydown', handler: $.proxy(this._tableUp, this) });
            this._events.push({ element: document, eventName: 'keydown', handler: $.proxy(this._tableDown, this) });

            $(document).on('keydown', null, 'Up', this._events[0].handler);
            $(document).on('keydown', null, 'Down', this._events[1].handler);

            if (this.options.actions) {
                var actions = this.options.actions;
                for (var i = 0; i < actions.length; i++) {
                    var action = actions[i];

                    var handlerProxy = $.proxy(this._executeAction, this, action.handler);

                    this._events.push({ element: document, eventName: 'keydown', handler: handlerProxy });
                    $(document).on('keydown', null, action.shortcut, handlerProxy);
                }
            }

            var rowClick = { element: this.tableElement, eventName: 'click', handler: $.proxy(this._tableRowClick, this) };
            this._events.push(rowClick);
            $(this.tableElement).on(rowClick.eventName, 'tbody tr', rowClick.handler);
        },

        _unsubscribeToEvents: function () {

            for (var i = 0; i < this._events.length; i++) {
                var event = this._events[i];
                $(event.element).off('keydown', event.handler);
            }
        },

        remove: function () {
            this._unsubscribeToEvents();
            delete this.tableElement.data().cursortable;
        }
    };

    $.fn.cursortable = function (option) {

        return this.each(function () {

            var $this = $(this);
            var data = $this.data('cursortable');
            var options = option;

            if (!data) $this.data('cursortable', (data = new CursorTable(this, options)));
            if (typeof option == 'string') data[option]();
        });
    };

})(jQuery);