Write-ASNotificationConfiguration -AutoScalingGroupName my-asg -NotificationType @("autoscaling:EC2_INSTANCE_LAUNCH", "autoscaling:EC2_INSTANCE_TERMINATE") -TopicARN "arn:aws:sns:us-west-2:123456789012:my-topic"