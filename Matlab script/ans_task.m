clear variables
close all;
clc;

datapath = "C:\Users\pelin\OneDrive\Masaüstü\Unity Projects\Beatz\ANS_Aquity_Game\Assets\Data";

cd(datapath)
%%
files = dir(fullfile(datapath, "*.csv"));
full_data = zeros(length({files(:).name}),9);

%% 
for i = 1:length({files(:).name})
    currdata = readtable(files(i).name); % change to i for all files

    % Convert the seconds into milliseconds for the ReactionTime

    currdata.ReactionTime = currdata.ReactionTime * 1000;
    
    % Check correctness for each block

    % Block 1
    block_one_responses = currdata((currdata.BlockNumber == 1),:);
    block_one_responses = block_one_responses(~(block_one_responses.Response == "noResponse"), :);
    block_one_responses.CorrectResponse = string(zeros(length(block_one_responses.TrialNumber)));
    
        % deleting the first and the last responses
    block_one_responses(end,:) = [];
    block_one_responses(1,:) = [];
    
    
    for a = 1:length(block_one_responses.TrialNumber)

        if block_one_responses.nrYellowDots(a) > block_one_responses.nrBlueDots(a)
            block_one_responses.CorrectResponse(a) = "Yellow";
            

        elseif block_one_responses.nrYellowDots(a) < block_one_responses.nrBlueDots(a)
            block_one_responses.CorrectResponse(a) = "Blue";

        end
       
    end

    block_one_responses = block_one_responses(~(block_one_responses.CorrectResponse == "0"), :);
    correct_block_one = block_one_responses(block_one_responses.CorrectResponse == block_one_responses.Response, :);
    
    perc_correct_block_one = length(correct_block_one.TrialNumber) ./ length(block_one_responses.TrialNumber) .* 100; 


    % Block 2
    block_two_responses = currdata((currdata.BlockNumber == 2),:);
    block_two_responses = block_two_responses(~(block_two_responses.Response == "noResponse"), :);
    block_two_responses.CorrectResponse = string(zeros(length(block_two_responses.TrialNumber)));

    block_two_responses(end,:) = [];
    block_two_responses(1,:) = [];   


    
    for a = 1:length(block_two_responses.TrialNumber)

        if block_two_responses.nrYellowDots(a) > block_two_responses.nrBlueDots(a)
            block_two_responses.CorrectResponse(a) = "Yellow";
            
        elseif block_two_responses.nrYellowDots(a) < block_two_responses.nrBlueDots(a)
            block_two_responses.CorrectResponse(a) = "Blue";

        end
    end
    block_two_responses = block_two_responses(~(block_two_responses.CorrectResponse == "0"), :);

    correct_block_two = block_two_responses(block_two_responses.CorrectResponse == block_two_responses.Response, :);

    perc_correct_block_two = length(correct_block_two.TrialNumber) ./ length(block_two_responses.TrialNumber) .* 100; 


    mean_rt_block_two = mean(block_two_responses.ReactionTime);

    


    % Block 3 
    block_three_responses = currdata((currdata.BlockNumber == 3),:);
    block_three_responses = block_three_responses(~(block_three_responses.Response == "noResponse"), :);

    block_three_responses(end,:) = [];
    block_three_responses(1,:) = [];
    block_three_responses.CorrectResponse = string(zeros(length(block_three_responses.TrialNumber)));

    
    for a = 1:length(block_three_responses.TrialNumber)

        if block_three_responses.nrYellowDots(a) > block_three_responses.nrBlueDots(a)
            block_three_responses.CorrectResponse(a) = "Yellow";          

                
          
        elseif block_three_responses.nrYellowDots(a) < block_three_responses.nrBlueDots(a)
            block_three_responses.CorrectResponse(a) = "Blue";

                 
            
        end
    end

    block_three_responses = block_three_responses(~(block_three_responses.CorrectResponse == "0"), :);
    correct_block_three = block_three_responses(block_three_responses.CorrectResponse == block_three_responses.Response, :);

    perc_correct_block_three = length(correct_block_three.TrialNumber) ./ length(block_three_responses.TrialNumber) .* 100; 
    mean_rt_block_three = mean(block_three_responses.ReactionTime);
    
    incong = block_three_responses((block_three_responses.Congruency == "Incongruent"), :);
    cong = block_three_responses((block_three_responses.Congruency == "Congruent"), :);
    
    correct_incong = incong(incong.CorrectResponse == incong.Response, :);    
    mean_rt_incong = mean(incong.ReactionTime);
    perc_incong = length(correct_incong.TrialNumber) ./ length(incong.TrialNumber) * 100;    
    

    mean_rt_cong = mean(cong.ReactionTime);
    correct_cong = cong(cong.CorrectResponse == cong.Response, :);
    perc_cong = length(correct_cong.TrialNumber) / length(cong.TrialNumber) * 100;

    full_data(i,1) = perc_correct_block_one;
    full_data(i,2) = perc_correct_block_two;
    full_data(i,3) = mean_rt_block_two;
    full_data(i,4) = perc_correct_block_three;
    full_data(i,5) = mean_rt_block_three;
    full_data(i,6) = perc_cong;
    full_data(i,7) = mean_rt_cong;
    full_data(i,8) = perc_incong;
    full_data(i,9) = mean_rt_incong;

end

%% Mean data from all participants

format short g

rt_block_two = mean(full_data(:,3));
rt_block_three = mean(full_data(:,5));
rt_cong = mean(full_data(:,7));
rt_incong = mean(full_data(:,9));

acc_block_one = mean(full_data(:,1));
acc_block_two = mean(full_data(:,2));
acc_block_three = mean(full_data(:,4));
acc_cong = mean(full_data(:,6));
acc_incong = mean(full_data(:,8));

%% Variances

format short g
var_rt_cong = std(full_data(:,7), "omitnan");
var_rt_incong = std(full_data(:,9), "omitnan");
var_acc_cong = std(full_data(:,6), "omitnan");
var_acc_incong = std(full_data(:,8), "omitnan");
var_acc_b1 = std(full_data(:,1), "omitnan");
var_acc_b2 = std(full_data(:,2), "omitnan");
var_acc_b3 = std(full_data(:,4), "omitnan");

var_rt_3 = std(full_data(:,5), "omitnan");
var_rt_2 = std(full_data(:,3), "omitnan");

%% Graph RT - cong vs incong

figure;
hold on
bar(1, rt_cong)
bar(2,rt_incong)
er=errorbar(2,rt_incong, var_rt_incong)
er.Color='Black';
er2=errorbar(1,rt_cong, var_rt_cong)
er2.Color='Black';
xticks([1 2])
xticklabels({"Congruous", "Incongruous"})

%% Graphs

% Bar plot RT Inc vs Cng

figure;
hold on

bar(1,acc_cong);
e = errorbar(1, acc_cong,var_acc_cong)
bar(2,acc_incong);
e = errorbar(2, acc_incong, var_acc_incong)
xticks([1 2])
xticklabels({"Congruous", "Incongruous"})
ylabel("Accuracy (%)")
title("Accuracy in congrous and incongrous trials")

figure;
hold on
bar(1, rt_block_three);
e = errorbar(1, rt_block_three, var_rt_3)
bar(2,rt_block_two);
e = errorbar(2, rt_block_two, var_rt_2)
xticks([1 2])
xticklabels({"Block 2", "Block 3"})
ylabel("Reaction Times (ms)")
title("Reaction Times in Block 2 and Block 3")

figure;
hold on
bar(1, acc_block_one);
e = errorbar(1, acc_block_one, var_acc_b1)
bar(2, acc_block_two);
e = errorbar(2, acc_block_two, var_acc_b2)
bar(3, acc_block_three);
e = errorbar(3, acc_block_three, var_acc_b3)
xticks([1 2 3])
xticklabels({"Block 1", "Block 2", "Block 3"})
title("Accuracy in all blocks (%)")



