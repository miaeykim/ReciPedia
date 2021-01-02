using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Recipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {                      
                        Name = "Açaí Bowl",
                        Category = "Desserts",
                        Ingredients = "3 (3.5-ounce) frozen açaí packs, 2 medium bananas, 1 c. frozen blueberries, 1 1/2 c. almond milk, Pinch of kosher salt",
                        Instruction = "Add the acai berry packet apple juice banana strawberries and blueberries to a high powered blender. Blend until smooth. Pour into a large bowl./ Top the bowl with as much (or as little) of your favorites such as granola fresh (thinly sliced) fruit chia seeds and coconut! I recommend drizzling on about a tablespoon of honey over everything. Enjoy immediately."
                    },
                    new Recipe
                    {
                        Name = "Turmeric smoothie bowl",
                        Category = "Desserts",
                        Ingredients = "10cm/4in fresh turmeric, 3 tbsp coconut milk yogurt, 2 bananas",
                        Instruction = "Peel the turmeric root if using and grate. Put all ingredients in a blender with 600ml water and blend until smooth. Serve in a bowl with chia seeds or some chopped nuts sprinkled over."
                    },
                    new Recipe
                    {
                        Name = "Cantaloupe Breakfast Bowls",
                        Category = "MainDish",
                        Ingredients = "1 cantaloupe,1 1/2 c. almond milk, 1 c. frozen raspberries, 1 banana (sliced into coin), 1/2 c. frozen pineapple",
                        Instruction = "Using a spoon remove and discard seeds from cantaloupe. Use a spoon to widen hole in the center leaving a 1\" border at the edges. Reserve removed fruit to add to smoothie./ Combine almond milk raspberries half the banana pineapple Greek yogurt vanilla and extra cantaloupe. Blend until smooth./ Pour smoothie into cantaloupe \"bowls\" and garnish with raspberries granola and remaining banana slices. Serve."
                    },
                    new Recipe
                    {
                        Name = "Chicken Provençal with olives & artichokes",
                        Category = "MainDish",
                        Ingredients = "2½kg chicken,8 garlic cloves (thinly sliced),200ml white wine,4 tbsp olive oil,1 tsp thyme leaves10 ripe plum tomatoes (halved),1 tbsp tomato purée,½ tsp herbes de Provence,1 tbsp fennel seeds,500ml chicken stock,1 celery stick finely (diced),15 button or silverskin onions or small shallots (peeled),285g jar chargrilled artichoke hearts (drained),100g pitted green olives",
                        Instruction = "Tip the chicken into a large bowl or dish and add the garlic wine 2 tbsp oil and the thyme. Season with 2 tbsp flaky salt and mix well until completely coated. Cover and chill for at least a few hours, but preferably overnight./ Heat grill to high. Arrange the plum tomatoes on a tray, cut-side up, drizzle with the remaining 1 tbsp oil and grill for 15 mins, or until charred. Set aside./ Heat 1 tbsp oil in a large casserole dish or flameproof roasting tin. Scrape the marinade off the chicken pieces back into the bowl and fry the chicken in batches for about 15 mins until the skin is golden and crisp – watch out, the oil has a tendency to sputter. Remove the chicken from the dish and pour off the oil. Place the dish back on the heat, add the tomato purée and cook for 2 mins, then add the herbs, fennel seeds, remaining marinade and chicken stock. Bring up to the boil, add the grilled tomatoes, then simmer gently for 20 mins./ Heat oven to 160C-140C fan-gas/ Nestle the chicken pieces back into the dish, then stir them in to coat in the sauce. Scatter over the celery, button onions and artichokes. Bring up to a simmer, pop the lid on, then transfer to the oven and cook for 1 hr. Remove the lid and stir in the olives. Season to taste and leave everything to settle for 15 mins before serving straight from the dish."
                    },
                    new Recipe
                    {
                        Name = "Jambalaya",
                        Category = "MainDish",
                        Ingredients = "2 tbsp olive oil,6 skinless boneless chicken thighs fillets,200g cooking chorizo,2 onions,4 garlic cloves,2 red peppers,2 celery sticks,1 tsp fresh thyme leaves,1 tsp dried oregano,½ tsp garlic salt,1 tsp smoked paprika,1 tsp cayenne pepper,½ tsp mustard powder,pinch of white pepper,300g long-grain rice,400g can cherry tomatoes,300ml chicken stock,12 large raw tiger prawns (whole in their shells),12 mussels,24 clams,½ small pack parsley,4 spring onions",
                        Instruction = "Heat oven to 200C-180C fan-gas 6. Heat the oil in a heavy-based flameproof casserole dish on a medium-high heat. Season the chicken thighs, add to the dish and cook for 4 mins until they start to brown, stirring occasionally so they don’t stick. Add the chorizo and cook for a further 4 mins until it releases its oils and has started to crisp. Remove the meat with a slotted spoon and set aside on a plate./ Add the onions to the chorizo oils, lower the heat and soften for 8 mins. Stir through the garlic, peppers, celery, thyme and oregano, and cook for 2 mins more./ Return the meat to the dish, add the garlic salt, paprika, cayenne, mustard powder and white pepper, and cook for 2 mins until fragrant. Stir in the rice, then the tomatoes. Add the stock and give it all a really good stir. Bring to the boil, then cover with a well-fitting lid and put in the oven for 20 mins./ Take from the oven and fluff up the rice with a big fork. Fold through the prawns, then put the mussels and clams on top. Put the lid on, return to the oven for 10 mins, then take the dish out and give everything a good stir. Sprinkle with the parsley and spring onions to serve."
                    },
                    new Recipe
                    {
                        Name = "Lentil salad with tahini dressing",
                        Category = "Salads",
                        Ingredients = "2 tbsp cold-pressed rapeseed oil,320g sweet potatoes,2 large carrots cut into thin sticks (320g),2 large courgettes (375g),2 medium red onions,1 tsp cumin seeds,2 tbsp finely chopped ginger,2 tbsp pumpkin seeds,2 x 390g cans green lentils,2 tsp vegetable bouillon powder,1 lemon, Good handful of mint,Handful of parsley,2.5-3 tbsp tahini,1 garlic clove,2 x 120g pot bio yogurt",
                        Instruction = "Heat the oil in a large non-stick wok. Add the sweet potato and fry for 5 mins, stirring frequently until it starts to soften. If it starts to brown too quickly, put a lid on the pan. Add the carrot, courgette, onion, cumin and ginger, then cook over a high heat, stirring frequently, until the veg is tender and a little charred. Stir in the seeds towards the end so they cook for a couple of mins. Remove from the heat and add the lentils, bouillon powder, lemon zest, mint and parsley./ Meanwhile, stir the tahini with the garlic, yogurt and 1 tbsp water to make a dressing. Spoon the lentil salad into bowls and top with the dressing and paprika, if using. If you're following our Healthy Diet Plan, save two portions stored in containers and chill until ready to eat."
                    },
                    new Recipe
                    {
                        Name = "French onion soup",
                        Category = "Soups",
                        Ingredients = "50g butter,1 tbsp olive oil,1kg onions (halved and thinly sliced),1 tsp sugar,4 garlic cloves2 tbsp plain flour,250ml dry white wine,1.3l hot strongly-flavoured beef stock,4-8 slices baguette (depending on size),140g gruyère (finely grated)",
                        Instruction = "Melt the butter with the olive oil in a large heavy-based pan. Add the onions and fry with the lid on for 10 mins until soft./ Sprinkle in the sugar and cook for 20 mins more, stirring frequently, until caramelised. The onions should be really golden, full of flavour and soft when pinched between your fingers. Take care towards the end to ensure that they don’t burn./ Add the garlic cloves for the final few minutes of the onions’ cooking time, then sprinkle in the plain flour and stir well/ Increase the heat and keep stirring as you gradually add the wine, followed by the beef stock. Cover and simmer for 15-20 mins./ To serve, turn on the grill, and toast the bread. Ladle the soup into heatproof bowls./ Put a slice or two of toast on top of the bowls of soup, and pile on the gruyère. Grill until melted. Alternatively, you can cook the toasts under the grill, then add them to the soup to serve."
                    },
                    new Recipe
                    {
                        Name = "Soup maker butternut squash soup",
                        Category = "Soups",
                        Ingredients = "½ butternut squash (about 500g),½ tbsp olive oil,1 onion (diced),1 small garlic clove (thinly sliced),1 mild red chilli (deseeded and finely chopped),400ml vegetable stock,2 tbsp crème fraîche (plus more to serve)",
                        Instruction = "Heat the oven to 200-180C fan-gas 6. Toss the butternut squash in a roasting tin with the olive oil. Season and roast for 30 mins, turning once during cooking, until golden and soft. / Put the roast squash into the soup maker, along with the onion, garlic, most of the chilli and all the stock. Make sure you don’t fill the soup maker above the max fill line. Season well. Press the ‘smooth soup’ function. / Once the cycle is complete, season well, and add the crème fraîche. Blend briefly once again until the soup is creamy. Add a little extra stock or boiling water if you prefer a thinner soup, and serve in bowls with a swirl of crème fraîche and the reserved chopped chilli. "
                    },
                    new Recipe
                    {
                        Name = "Homemade hot chocolate",
                        Category = "Beverages",
                        Ingredients = "250ml milk of your choice,1 tbsp cocoa,1-2 tbsp soft light brown sugar,25g dark or plain chocolate (finely chopped),1 tbsp whipped cream or squirty cream",
                        Instruction = "Heat the milk, cocoa, sugar and chocolate in a small pan over a medium heat until steaming and the chocolate has melted. Whisk to dissolve the cocoa./ Pour into a mug, then add the cream to float on top. Grate over a little more chocolate to serve."
                    },
                    new Recipe
                    {
                        Name = "Peach punch",
                        Category = "Beverages",
                        Ingredients = "4 tbsp caster sugar,zest and juice 1½ lemon,750ml bottle rosé wine,150ml peach schnapps,1 peach (sliced),1⁄2 lemon (sliced),ice cubes,1l bottle of soda water or tonic",
                        Instruction = "Heat the sugar with the lemon zest and 100ml water until the sugar dissolves. Cool, pour into a jug and add the wine, lemon juice and schnapps./ When ready to serve add plenty of ice and the fruit and top up with the soda or tonic to taste."
                    },
                    new Recipe
                    {
                        Name = "Orange-Glazed Meatballs",
                        Category = "Appetizers",
                        Ingredients = "1 package (22 ounces) frozen fully cooked angus beef meatballs,1 jar (12 ounces) orange marmalade,1/4 cup orange juice,3 green onions (divided),1 jalapeno pepper (seeded and chopped)",
                        Instruction = "Prepare meatballs according to package directions./ In a small saucepan, heat the marmalade, orange juice, half of the green onions and the jalapeno./ Place meatballs in a serving dish; pour glaze over the top and gently stir to coat. Garnish with remaining green onions."
                    },
                    new Recipe
                    {
                        Name = "Pretzel Bread Bowl with Cheese Dip",
                        Category = "Appetizers",
                        Ingredients = "1 package (8 ounces) cream cheese1 package (10 ounces) sharp white cheddar cheese (cut into 1/4-inch slices),1/3 cup pimiento-stuffed olives,1/3 cup pitted Greek olives,1/4 cup balsamic vinegar,1/4 cup olive oil,1 tablespoon minced fresh parsley,1 tablespoon minced fresh basil or 1 teaspoon dried basil,2 garlic cloves (minced),1 jar (2 ounces) pimiento strips (drained and chopped),Toasted French bread baguette slices",
                        Instruction = "Cut cream cheese lengthwise in half; cut each half into 1-4-in. slices. On a serving plate, arrange cheeses upright in a ring, alternating cheddar and cream cheese slices. Place olives in center./ In a small bowl, whisk vinegar, oil, parsley, basil and garlic until blended; drizzle over cheeses and olives. Sprinkle with pimientos. Refrigerate, covered, at least 8 hours or overnight. Serve with baguette slices."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}