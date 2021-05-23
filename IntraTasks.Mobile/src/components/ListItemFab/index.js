import React from 'react';

import {colors} from 'react-native-elements';
import {FAB} from 'react-native-elements/dist/buttons/FAB';
import {Icon} from 'react-native-elements/dist/icons/Icon';

export function ListItemFab({
  icon: iconName = '',
  color = colors.primary,
  buttonSize = 15,
  size = 'small',
  ...rest
}) {
  return (
    <FAB
      {...rest}
      icon={
        <Icon
          color="white"
          size={buttonSize}
          name={iconName}
          type="font-awesome"
        />
      }
      size={size}
      color={color}
    />
  );
}
