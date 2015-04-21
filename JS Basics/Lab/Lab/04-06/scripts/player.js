var Player = (function(){
    function Player(x, y) {
        this.position = new Vector2(x, y);
        this.movement = {left: false, right : false, up: false, down : false};
        this.velocity = 20;

        this.width = 128;
        this.height = 48;

        this.animation = new Animation( this.width, this.height, 0, 0, 1, 'ressources/images/paddles.PNG', 1, 1, 1);
        this.boundingBox = new Rectangle ( x, y, this.width, this.height)
    }

    Player.prototype.update = function() {
        if(this.movement.right) {
            this.position.x += this.velocity;
        } else if(this.movement.left) {
            this.position.x -= this.velocity;
        }

        if(this.movement.up) {
            this.position.y -= this.velocity;
        } else if(this.movement.down) {
            this.position.y += this.velocity;
        }

        this.animation.position.set(this.position.x, this.position.y);
        this.boundingBox.x = this.position.x;
        this.boundingBox.y = this.position.y;

        this.animation.update();
    };

    Player.prototype.render = function(ctx) {
        this.animation.draw(ctx);
    };

    return Player;
}());