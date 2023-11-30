// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    const txts= document.querySelector(".animate-text").children;
    txtslen= txts.length;
    let index =0;
    const textInTimer = 3000,
    textOutTimer = 2800;

    function animateText(){
            for(let i =0 ; i <txtslen;i++ ){
        txts[i].classList.remove("text-in", "text-out");
            }

    txts[index].classList.add("text-in");

    setTimeout(function(){
        txts[index].classList.add("text-out");
            },textOutTimer)



    setTimeout(function(){
                
                if(index == txtslen-1){
        index = 0;
                }
    else{
        index++;
                }
    animateText();
            },textInTimer);

        }
    window.onload=animateText;
